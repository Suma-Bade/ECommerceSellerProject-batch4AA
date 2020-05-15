using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AccountService.Manager;
using AccountService.Models;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace AccountService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly IAccountManager _iAccountManager;
        private readonly ILogger<AccountController> _logger;
        private readonly IConfiguration configuration;

        public AccountController(IAccountManager iAccountManager, ILogger<AccountController> logger, IConfiguration configuration)
        {

            _iAccountManager = iAccountManager;
            _logger = logger;
            this.configuration = configuration;
        }
        /// <summary>
        /// Add a new Seller to a List.
        /// </summary>
        /// <param name="userDetails"></param>
        /// <returns></returns>
        /// /// <response code="200">Successful operation</response>
        /// <response code="400">Bad Request/Request Invalid </response>
        /// <response code="404">Requested Resouce  not found</response>
        /// <response code="500">Internal server Error</response>
        [HttpPost]
        [Route("REGISTER-SELLER")]
        [ProducesResponseType(200, Type = typeof(bool))]
        [ProducesResponseType(404, Type = typeof(string))]
        public async Task<IActionResult> SellerRegister(SellerRegister seller)
        {

            _logger.LogInformation("Register");
            if (seller is null)
            {
                return BadRequest("Seller already exists");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _iAccountManager.SellerRegister(seller);
            _logger.LogInformation("Succesfully Registered");
            return Ok();
        }
        /// <summary>
        /// Login with username and password
        /// </summary>
        /// <param name="SellerLogin"></param>
        /// <returns></returns>
        /// /// <response code="200">Successful operation</response>
        /// <response code="400">Bad Request/Request Invalid </response>
        /// <response code="404">Requested Resouce  not found</response>
        /// <response code="500">Internal server Error</response>
        [HttpGet]
        [Route("SellerLogin/{username}/{password}")]
        public async Task<IActionResult> SellerLogin(string username, string password)
        {
            Token token = null;
            _logger.LogInformation("User Login");

            SellerLogin login1 = await _iAccountManager.ValidateSeller(username, password);
            if (login1 != null)
            {
                token = new Token() { sellerid = login1.sellerid, username = login1.Username, token = GenerateJwtToken(username), message = "Success" };
            }
            else
            {
                token = new Token() { token = null, message = "UnSuccess" };
            }
            _logger.LogInformation($"Welcome{username}");
            return Ok(token);
        }
        private string GenerateJwtToken(string username)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, username),
                new Claim(ClaimTypes.Role,username)
            };
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            // recommended is 5 min
            var expires = DateTime.Now.AddDays(Convert.ToDouble(configuration["JwtExpireDays"]));
            var token = new JwtSecurityToken(
                configuration["JwtIssuer"],
                configuration["JwtIssuer"],
                claims,
                expires: expires,
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
