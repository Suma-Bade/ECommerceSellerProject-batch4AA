using AccountService.Entities;
using AccountService.Manager;
using AccountService.Models;
using AccountService.Repositories;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestAccountProject
{
    public class TestAccountManager
    {
        private IAccountManager AccountManager;
        [SetUp]
        public void SetUp()
        {
            AccountManager = new AccountManager(new AccountRepository(new ECommerceDBContext()));
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
        [TestCase(9090, "parnitha", "parnitha@", "6475JH6754", "virtusa", "good", "bangalore", "www.virtusa.com", "parnitha@gmail.com", "9123479543")]
        //[TestCase("aarush", "aarush!", "tcs", "good", "chennai", "www.tcs.com", "aarush@gmail.com", "9973473256")]
        [Description("Test for SellerRegistration Success")]
        public void TestSellerRegister(int sid, string username, string password, string companyname, int gst, string aboutcmpy, string address, string website, string email, string mobileno)
        {
            
            try
            {
                var Datetime = System.DateTime.Now;
                var seller = new SellerRegister { Sellerid = sid, Username = username, Password = password, Companyname = companyname, Gst = gst, Aboutcmpy = aboutcmpy, Address = address, Website = website, Email = email, Mobileno = mobileno };
                var res = AccountManager.SellerRegister(seller);
                var mock = new Mock<IAccountManager>();
                mock.Setup(x => x.SellerRegister(seller));
                Assert.AreEqual(res.Result, true);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }

        }
        [Test]
        [TestCase()]
        // [TestCase(65544, "renu", "renu777", "virtusa", 34, "good", "bangalore", "www.virtusa.com", "renusri@gmail.com", "9123479543")]
        [Description("Test for SellerRegistration UnSuccess")]
        public void TestSellerRegister_Unsuccess(int sid, string username, string password, string companyname, int gst, string aboutcmpy, string address, string website, string email, string mobileno)
        {

            try
            {
                var Datetime = System.DateTime.Now;
                var seller = new SellerRegister { Sellerid = sid, Username = username, Password = password, Companyname = companyname, Gst = gst, Aboutcmpy = aboutcmpy, Address = address, Website = website, Email = email, Mobileno = mobileno };
                var res = AccountManager.SellerRegister(seller);
                var mock = new Mock<IAccountManager>();
                mock.Setup(x => x.SellerRegister(seller));
                Assert.AreEqual(res.Result, true);
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

        [Description("Seller Login Success")]
        public void SellerLogin_Success()
        {
            try
            {
                var result = AccountManager.ValidateSeller("suma", "bade123");
                Assert.IsNotNull(result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [Test]
        [Description("Seller Login UnSuccess")]
        public void SellerLogin_Unsuccess()
        {
            try
            {
                var result = AccountManager.ValidateSeller("srija", "srija12123");
                Assert.IsNotNull(result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }

        }

    }
}
  
