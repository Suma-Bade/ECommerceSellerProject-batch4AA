using AccountService.Controllers;
using AccountService.Entities;
using AccountService.Manager;
using AccountService.Models;
using AccountService.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;

namespace NUnitAccountTestProject
{
    [TestFixture]
    public class TestAccountController
    {
        private AccountController accountController;
        private Mock<IAccountManager> mockAccountManager;
        private Mock<ILogger<AccountController>> logger;
        [SetUp]
        public void Setup()
        {
            mockAccountManager = new Mock<IAccountManager>();
            logger = new Mock<ILogger<AccountController>>();
            accountController = new AccountController(mockAccountManager.Object, logger.Object);

        }
        [Test]
        [TestCase(9090, "prethi", "prethi88", "virtusa", 34, "good", "bangalore", "www.virtusa.com", "prethi@gmail.com", "9123479543")]
        [Description("Test for SellerRegistration Success")]
        public async Task TestSellerRegister_Success(int sid, string username, string password, string companyname, int gst, string aboutcmpy, string address, string website, string email, string mobileno)
        {
            try
            {
                SellerRegister sellerRegister= new SellerRegister() { Username = username, Password = password, Companyname = companyname, Aboutcmpy = aboutcmpy, Address = address, Website = website, Email = email, Mobileno = mobileno };
               mockAccountManager.Setup(x => x.SellerRegister(sellerRegister)).ReturnsAsync(true);
                var result = await accountController.SellerRegister(sellerRegister);
                Assert.That(result, Is.Not.Null);
                //Assert.That(result.StatusCode, Is.EqualTo(200));
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
       
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [Test]
        [TestCase("suma", "bade123")]
        [Description("Seller Login")]
        public async Task SellerLogin_Successfull(string uname, string pwd)
        {
            try
            {
                SellerLogin login = new SellerLogin() { Username = uname, Password = pwd };
                var result = await accountController.SellerLogin(login);
                Assert.That(result, Is.Not.Null);
                //Assert.That(result.StatusCode, Is.EqualTo(200));
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
       
       
        
    }
}
    

