using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AccountService.Manager;
using AccountService.Models;

namespace AccountService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        
        private readonly IAccountManager _iAccountManager;
       private readonly ILogger<AccountController> _logger;
        public AccountController( IAccountManager iAccountManager, ILogger<AccountController> logger)
        {
            
            _iAccountManager = iAccountManager;
            _logger = logger;
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
        [HttpPost]
        [Route("UserLogin")]
        [ProducesResponseType(200, Type = typeof(SellerLogin))]
        [ProducesResponseType(404, Type = typeof(string))]
        [HttpGet]
        [Route("SellerLogin/{username}/{password}")]
        public async Task<IActionResult> SellerLogin(string username, string password)
        {
            //Input is userName and userPassword 
            //Returns  respected SellerLogin if the entered credentials are valid else it gives an invalid message

            _logger.LogInformation("Login");
            SellerLogin seller = await _iAccountManager.ValidateSeller(username, password);

            if (seller == null)
            {
                //Null Checking-
                return Ok("Invalid User");
            }
            else
            {
                _logger.LogInformation($"Welcome {seller.Username}");
                return Ok(seller);
            }
        }

    }
}
