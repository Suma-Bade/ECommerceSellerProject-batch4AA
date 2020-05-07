using AccountService.Entities;
using AccountService.Models;
using AccountService.Repositories;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTesting
{
    [TestFixture]
    public class TestAccountRepository
    {
        IAccountRepository AccountRepository;
        [SetUp]
        public void SetUp()
        {
            AccountRepository = new AccountRepository(new ECommerceDBContext());
        }
        [TearDown]
        public void TearDown()
        {
            AccountRepository = null;
        }

        /// <summary>
        /// Testing register seller
        /// </summary>
        [Test]
        [TestCase(3768, "pranathi", "pranathi@", "mindtree", 34, "good", "bangalore", "www.mindtree.com", "pranathi@gmail.com", "9123409043")]
        [TestCase(5778, "alekhya", "alekhya!", "tcs", 74, "good", "chennai", "www.tcs.com", "alekhya@gmail.com", "9090473256")]
        [Description("To test whether details of seller are added to database")]
        public void TestSellerRegister(int sid, string username, string password, string companyname, int gst, string aboutcmpy, string address, string website, string email, string mobileno)
        {
            var Datetime = System.DateTime.Now;
            var seller = new SellerRegister { Sid = sid, Username = username, Password = password, Companyname = companyname, Gst = gst, Aboutcmpy = aboutcmpy, Address = address, Website = website, Email = email, Mobileno = mobileno };
            AccountRepository.SellerRegister(seller);
            var mock = new Mock<IAccountRepository>();
            mock.Setup(x => x.SellerRegister(seller));
            var result = AccountRepository.ValidateSeller(username, password);
            Assert.NotNull(result);
        }
        [Test]
        [Description("To test whether given credentials exist in the database")]
        public void TestSellerLogin_Successful()
        {

            Task<SellerLogin> result = AccountRepository.ValidateSeller("manasa", "manasa@");
            SellerLogin seller = result.Result;
            Assert.NotNull(seller.Username);

        }
        [Test]
        [Description("Test seller login failure case")]
        public void TestSellerLogin_unSuccessfull()
        {

            Task<SellerLogin> result = AccountRepository.ValidateSeller("suma", "bade");
            Assert.AreEqual(result.Result, null);

        }
    }
}
