using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountService.Extensions;
using AccountService.Entities;
using AccountService.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using static AccountService.Extensions.CustomExceptionFilter;
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
        [HttpPost]
        [Route("REGISTER-SELLER")]
        public async Task<bool> SellerRegister(SellerRegister seller)
        {

            _logger.LogInformation("Register");
            
            
            //Null Checking -
           var result= await _iAccountManager.SellerRegister(seller);
            _logger.LogInformation($"Succesfully Registered");
            if(result==true)
            {
                return result;
            }
            return result;

        }
        [HttpGet]
        [Route("SellerLogin/{username}/{password}")]
        public async Task<IActionResult> SellerLogin(string username, string password)
        {

           _logger.LogInformation("Login");
            var seller = await _iAccountManager.ValidateSeller(username, password);

            if (seller != null)
            {
                //Null Checking-
                return Ok(seller);
            }
            _logger.LogInformation($"Welcome {seller.Username}");
            return Ok(seller);

        }

        public Task<Seller> SellerLogin(SellerLogin user)
        {
            throw new NotImplementedException();
        }
    }
}
