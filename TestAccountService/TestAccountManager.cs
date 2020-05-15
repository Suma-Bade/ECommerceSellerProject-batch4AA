using AccountService.Manager;
using AccountService.Models;
using AccountService.Repositories;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace TestAccountService
{
    public class TestAccountManager
    {
        IAccountManager AccountManager;
        private Mock<IAccountRepository> mockAccountManager;
        [SetUp]
        public void SetUp()
        {
            mockAccountManager = new Mock<IAccountRepository>();
            AccountManager = new AccountManager(mockAccountManager.Object);
        }
        [TearDown]
        public void TearDown()
        {
            AccountManager = null;

        }
        /// <summary>
        /// Testing register seller functionality for a new seller
        /// </summary>
        [Test]
        [TestCase(9090, "parnitha", "parnitha@", "virtusa", 789890, "good", "bangalore", "www.virtusa.com", "parnitha@gmail.com", "9123479543")]
        //[TestCase("aarush", "aarush!", "tcs", "good", "chennai", "www.tcs.com", "aarush@gmail.com", "9973473256")]
        [Description("Test for SellerRegistration Success")]
        public async Task TestSellerRegister(int sid, string username, string password, string companyname, int gst, string aboutcmpy, string address, string website, string email, string mobileno)
        {

            try
            {
                var seller = new SellerRegister { Sellerid = sid, Username = username, Password = password, Companyname = companyname, Gst = gst, Aboutcmpy = aboutcmpy, Address = address, Website = website, Email = email, Mobileno = mobileno };
                var mock = new Mock<IAccountRepository>();
                mock.Setup(x => x.SellerRegister(seller)).ReturnsAsync(true);
                AccountManager accountManager = new AccountManager(mock.Object);
                var result = await accountManager.SellerRegister(seller);
                Assert.IsNotNull(result, "test method failed SellerRegister method is null");
                Assert.AreEqual(true, result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }

        }
        /// <summary>
        /// Testing register seller functionality for a new seller fails if already registered
        /// </summary>
        [Test]
        [TestCase(9090, "parnitha", "parnitha@", "virtusa", 789890, "good", "bangalore", "www.virtusa.com", "parnitha@gmail.com", "9123479543")]
        // [TestCase(65544, "renu", "renu777", "virtusa", 34, "good", "bangalore", "www.virtusa.com", "renusri@gmail.com", "9123479543")]
        [Description("Test for SellerRegistration UnSuccess")]
        public async Task TestSellerRegister_Unsuccess(int sid, string username, string password, string companyname, int gst, string aboutcmpy, string address, string website, string email, string mobileno)
        {

            try
            {
                var seller = new SellerRegister { Sellerid = sid, Username = username, Password = password, Companyname = companyname, Gst = gst, Aboutcmpy = aboutcmpy, Address = address, Website = website, Email = email, Mobileno = mobileno };
                var mock = new Mock<IAccountRepository>();
                mock.Setup(x => x.SellerRegister(seller)).ReturnsAsync(false);
                AccountManager accountManager = new AccountManager(mock.Object);
                var result = await accountManager.SellerRegister(seller);
                Assert.IsNotNull(result, "test method failed SellerRegister method is null");
                Assert.AreEqual(false, result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }

        }
        [Test]
        // <summary>
        /// Service should return seller if correct usename and password is supplied
        /// </summary>
        [TestCase("rahul", "rahul123")]
        [TestCase("pranitha", "pranitha@")]
        [Description("Seller Login Success returns seller details")]
        public async Task SellerLogin_Success(string username, string password)
        {
            try
            {
                var seller = new SellerLogin();
                var mock = new Mock<IAccountRepository>();
                mock.Setup(x => x.ValidateSeller(username, password)).ReturnsAsync(seller);
                AccountManager accountManager = new AccountManager(mock.Object);
                var result = await accountManager.ValidateSeller(username, password);
                Assert.IsNotNull(result, "test method fail SellerLogin method is null");
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [Test]
        [TestCase("renu", "renu23")]
        [Description("Seller Login UnSuccess")]
        public async Task SellerLogin_Unsuccess(string username, string password)
        {
            try
            {
                var mock = new Mock<IAccountRepository>();
                mock.Setup(x => x.ValidateSeller(username, password)).ReturnsAsync((SellerLogin)(null));
                AccountManager accountManager = new AccountManager(mock.Object);
                var result = await accountManager.ValidateSeller(username, password);
                Assert.IsNull(result, "test method fail SellerLogin method is not null");
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }

        }

    }
}

