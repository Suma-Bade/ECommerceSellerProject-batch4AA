using AccountService.Entities;
using AccountService.Models;
using AccountService.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TestAccountProject
{
    [TestFixture]
    public class TestAccountRepository
    {
        IAccountRepository AccountRepository;
        DbContextOptionsBuilder<ECommerceDBContext> _builder;
        [SetUp]
        public void SetUp()
        {
            _builder = new DbContextOptionsBuilder<ECommerceDBContext>().EnableSensitiveDataLogging().UseInMemoryDatabase(Guid.NewGuid().ToString());
            ECommerceDBContext eCommerceDBContext = new ECommerceDBContext(_builder.Options);
            AccountRepository = new AccountRepository(eCommerceDBContext);
            eCommerceDBContext.Seller.Add(new Seller { Sellerid = 700, Username ="kalyani", Password ="kalyani@", Companyname ="infosys", Gst = 47, Aboutcmpy ="gud", Address = "bangalore", Website ="www.infy.com", Email ="priya13@gmail.com", Mobileno ="9535678900"        });
            eCommerceDBContext.SaveChanges();
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
            var seller = new SellerRegister { Sellerid = sid, Username = username, Password = password, Companyname = companyname, Gst = gst, Aboutcmpy = aboutcmpy, Address = address, Website = website, Email = email, Mobileno = mobileno };
            AccountRepository.SellerRegister(seller);
            var mock = new Mock<IAccountRepository>();
            mock.Setup(x => x.SellerRegister(seller));
            var result = AccountRepository.ValidateSeller(username, password);
            Assert.NotNull(result);
        }
        [Test]
        [TestCase("priyanka", "priyanka@")]
        [Description("testing seller login")]
        public async Task SellerLogin_Successfull(string username, string password)
        {
            try
            {
                var result = await AccountRepository.ValidateSeller(username, password);
                Assert.NotNull(result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [Test]
        [TestCase("priya", "priyanka")]
        [Description("Test seller login failure case")]
        public async Task SellerLogin_UnSuccessfull(string username, string password)
        {
            try
            {
                var result = await AccountRepository.ValidateSeller(username, password);
                Assert.IsNull(result, "Invalid");
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
    }

}

