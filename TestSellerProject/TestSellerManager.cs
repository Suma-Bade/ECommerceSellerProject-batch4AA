using Moq;
using NUnit.Framework;
using SellerService.Entities;
using SellerService.Manager;
using SellerService.Models;
using SellerService.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TestSellerService
{
    [TestFixture]
    public class TestSellerManager
    {
        ISellerManager iSellerManager;

        [SetUp]
        public void SetUp()
        {
            iSellerManager = new SellerManager(new SellerRepository(new ECommerceDBContext()));
        }

        [TearDown]
        public void TearDown()
        {
            iSellerManager = null;
        }
        /// <summary>
        /// Testing seller profile
        /// </summary>
        [Test]
        [TestCase(2)]
        [TestCase(7)]
        [Description("testing seller Profile")]
        public async Task SellerProfileSuccess(int sid)
        {
            try
            {
                SellerDetails seller = new SellerDetails();
                var mock = new Mock<ISellerRepository>();
                mock.Setup(x => x.ViewSellerProfile(sid)).ReturnsAsync(seller);
                SellerManager sellerManager = new SellerManager(mock.Object);
                var result = await sellerManager.ViewSellerProfile(sid);
                Assert.NotNull(result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /// <summary>
        /// Testing buyer profile
        /// </summary>
        /// <summary>
        /// Testing seller profile
        /// </summary>
        [Test]
        [TestCase(404)]
        [TestCase(500)]
        [Description("testing seller Profile failure")]
        public async Task SellerProfile_UnSuccessfull(int sid)
        {
            try
            {
                SellerDetails seller = new SellerDetails();
                var mock = new Mock<ISellerRepository>();
                mock.Setup(x => x.ViewSellerProfile(sid));
                SellerManager sellerManager = new SellerManager(mock.Object);
                var result = await sellerManager.ViewSellerProfile(sid);
                Assert.IsNull(result, "invalid seller");
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [Test]
        [Description("testing seller edit Profile")]
        public async Task EditSellerProfile_Success()
        {
            try
            {
                SellerDetails seller = new SellerDetails() { Sellerid = 1234, Username = "manaswi", Password = "manaswi@", Companyname = "accenture", Gst = 78, Aboutcmpy = "good", Address = "mumbai", Website = "www.accenture.com", Email = "manaswi@gmail.com", Mobileno = "9478654567" };
                var mock = new Mock<ISellerRepository>();
                mock.Setup(x => x.EditSellerProfile(seller)).ReturnsAsync(true);
                SellerManager sellerManager = new SellerManager(mock.Object);
                var result = await sellerManager.EditSellerProfile(seller);
                Assert.IsNotNull(result);
                Assert.AreEqual(true, result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [Test]
        [Description("testing seller edit Profile")]
        public async Task EditSellerProfile_UnSuccess()
        {
            try
            {
                SellerDetails seller = new SellerDetails() { Sellerid = 508, Username = "manaswi", Password = "manaswi@", Companyname = "accenture", Gst = 78, Aboutcmpy = "good", Address = "mumbai", Website = "www.accenture.com", Email = "manaswi@gmail.com", Mobileno = "9478654567" };
                var mock = new Mock<ISellerRepository>();
                mock.Setup(x => x.EditSellerProfile(seller)).ReturnsAsync(false);
                SellerManager sellerManager = new SellerManager(mock.Object);
                var result = await sellerManager.EditSellerProfile(seller);
                Assert.AreEqual(false, result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

    }
}


