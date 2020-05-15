using AccountService.Controllers;
using AccountService.Manager;
using AccountService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace TestAccountService
{
    [TestFixture]
    public class TestAccountController
    {
        private AccountController accountController;
        private Mock<IAccountManager> mockAccountManager;
        private Mock<ILogger<AccountController>> logger;
        private Mock<IConfiguration> configuration;
        [SetUp]
        public void Setup()
        {
            configuration = new Mock<IConfiguration>();
            mockAccountManager = new Mock<IAccountManager>();
            logger = new Mock<ILogger<AccountController>>();
            accountController = new AccountController(mockAccountManager.Object, logger.Object,configuration.Object);

        }
        /// <summary>
        /// To Test For new user to register
        /// </summary>
        /// <returns></returns>
        [Test]
        [TestCase(9090, "prethi", "prethi88", "virtusa", 34, "good", "bangalore", "www.virtusa.com", "prethi@gmail.com", "9123479543")]
        [Description("Test for SellerRegistration Success")]
        public async Task TestSellerRegister_valid_Returns(int sid, string username, string password, string companyname, int gst, string aboutcmpy, string address, string website, string email, string mobileno)
        {
            try
            {
                var sellerRegister = new SellerRegister() { Username = username, Password = password, Companyname = companyname, Gst = gst, Aboutcmpy = aboutcmpy, Address = address, Website = website, Email = email, Mobileno = mobileno };
                mockAccountManager.Setup(d => d.SellerRegister(It.IsAny<SellerRegister>())).ReturnsAsync(new bool());
                var result = await accountController.SellerRegister(sellerRegister) as OkResult;
                Assert.That(result, Is.Not.Null);
                Assert.That(result.StatusCode, Is.EqualTo(200));

            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /// <summary>
        /// To get details of a particular seller by using username and password
        /// </summary>

        /// <returns></returns>
        [Test]
        [TestCase("suma", "bade123")]
        [Description("Seller Login")]
        public async Task SellerLogin_Successfull_Returns_NotNull(string username, string password)
        {
            try
            {
                mockAccountManager.Setup(x => x.ValidateSeller(username, password));
                var result = await accountController.SellerLogin(username, password) as OkObjectResult;
                Assert.That(result, Is.Not.Null);
                Assert.That(result.StatusCode, Is.EqualTo(200));

            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /// <summary>
        /// To Test for failure of SellerLogin of a particular seller and gives response message
        /// </summary>

        /// <returns></returns>
        [Test]
        [TestCase("suma", "suma123")]
        [Description("Seller Login")]
        public async Task SellerLogin_Fail_Returns_Null(string username, string password)
        {
            try
            {
                mockAccountManager.Setup(x => x.ValidateSeller(username, password)).ReturnsAsync((SellerLogin)(null));
                var result = await accountController.SellerLogin(username, password) as OkObjectResult;
                Assert.That(result, Is.Null);
                Assert.That(result.StatusCode, Is.EqualTo(200));

            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }



    }
}


