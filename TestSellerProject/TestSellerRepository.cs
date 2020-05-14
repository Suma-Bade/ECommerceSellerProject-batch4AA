using Moq;
using NUnit.Framework;
using SellerService.Entities;
using SellerService.Manager;
using SellerService.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SellerService.Models;
using Microsoft.EntityFrameworkCore;

namespace TestSellerService
{
    public class TestSellerRepository
    {
        ISellerRepository sellerRepository;

        DbContextOptionsBuilder<ECommerceDBContext> _builder;
        [SetUp]
        public void SetUp()
        {
            _builder = new DbContextOptionsBuilder<ECommerceDBContext>().EnableSensitiveDataLogging().UseInMemoryDatabase(Guid.NewGuid().ToString());
            ECommerceDBContext eCommerceDBContext = new ECommerceDBContext(_builder.Options);
            sellerRepository = new SellerRepository(eCommerceDBContext);
            eCommerceDBContext.Seller.Add(new Seller { Sellerid = 800, Username = "priyanka", Password = "priyanka@", Companyname = "infosys", Gst = 47, Aboutcmpy = "gud", Address = "bangalore", Website = "www.infy.com", Email = "priya13@gmail.com", Mobileno = "9535678900" });
            eCommerceDBContext.SaveChanges();
        }

        [TearDown]
        public void TearDown()
        {
            sellerRepository = null;
        }
        /// <summary>
        /// Testing seller profile
        /// </summary>
        [Test]
        [TestCase(2)]
        [TestCase(7)]
        [Description("testing seller Profile")]
        public async Task SellerProfile_Successfull(int sellerid)
        {
            try
            {
                var result = await sellerRepository.ViewSellerProfile(sellerid);
                var mock = new Mock<ISellerRepository>();
                mock.Setup(x => x.ViewSellerProfile(sellerid));
                Assert.NotNull(result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /// <summary>
        /// Testing seller profile
        /// </summary>
        [Test]
        [TestCase(458)]
        [TestCase(322)]
        [Description("testing seller Profile failure")]
        public async Task SellerProfile_UnSuccessfull(int sellerid)
        {
            try
            {
                var result = await sellerRepository.ViewSellerProfile(sellerid);
                var mock = new Mock<ISellerRepository>();
                mock.Setup(x => x.ViewSellerProfile(sellerid));
                Assert.IsNull(result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /// <summary>

        /// </summary>
        [Test]
        [Description("testing seller edit Profile")]
        public async Task EditSellerProfile_Successfull()
        {
            try
            {
                SellerDetails seller = new SellerDetails() { Sellerid = 1234, Username = "manaswi", Password = "manaswi@", Companyname = "accenture", Gst = 78, Aboutcmpy = "good", Address = "mumbai", Website = "www.accenture.com", Email = "manaswi@gmail.com", Mobileno = "9478654567" };
                var mock = new Mock<ISellerRepository>();
                mock.Setup(x => x.EditSellerProfile(seller)).ReturnsAsync(true);
                var result = await sellerRepository.EditSellerProfile(seller);
                Assert.IsNotNull(result);
                Assert.AreEqual(true, result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /// <summary>
        /// Testing seller profile
        /// </summary>
        [Test]
        [Description("testing seller edit Profile")]
        public async Task EditSellerProfile_UnSuccessfull()
        {
            try
            {

                SellerDetails seller = new SellerDetails() { Sellerid = 507, Username = "manaswi", Password = "manaswi@", Companyname = "accenture", Gst = 78, Aboutcmpy = "good", Address = "mumbai", Website = "www.accenture.com", Email = "manaswi@gmail.com", Mobileno = "9478654567" };
                var mock = new Mock<ISellerRepository>();
                mock.Setup(x => x.EditSellerProfile(seller)).ReturnsAsync(false);
                var result = await sellerRepository.EditSellerProfile(seller);
                Assert.AreEqual(false, result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }

        }

    }
}




