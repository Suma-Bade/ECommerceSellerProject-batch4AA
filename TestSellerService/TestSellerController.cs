using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using SellerService.Controllers;
using SellerService.Manager;
using SellerService.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TestSellerProject
{
    [TestFixture]
    public class TestSellerController
    {
        SellerController sellerController;
        private Mock<ISellerManager> mockSellerManager;
        [SetUp]
        public void SetUp()
        {
            mockSellerManager = new Mock<ISellerManager>();
            sellerController = new SellerController(mockSellerManager.Object);
        }

        [TearDown]
        public void TearDown()
        {
            sellerController = null;
        }
        /// <summary>
        /// Testing seller profile
        /// </summary>
        [Test]
        [TestCase(3578)]
        [TestCase(3768)]
        [Description("testing seller Profile")]
        public async Task SellerProfile_Successfull(int sellerid)
        {
            try
            {
                mockSellerManager.Setup(x => x.ViewSellerProfile(sellerid));
                var result = await sellerController.ViewSellerProfile(sellerid);
                Assert.That(result, Is.Not.Null);
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
        [TestCase(567)]
        [TestCase(478)]
        [Description("testing seller Profile failure")]
        public async Task SellerProfile_UnSuccessfull(int sellerid)
        {
            try
            {
                mockSellerManager.Setup(d => d.ViewSellerProfile(sellerid)).ReturnsAsync((SellerDetails)(null));
                var result = await sellerController.ViewSellerProfile(sellerid) as OkResult;
                Assert.That(result, Is.Null);
                Assert.That(result.StatusCode, Is.EqualTo(200));
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /// <summary>
        /// Testing buyer profile
        /// </summary>
        [Test]
        [Description("testing seller edit Profile")]
        public async Task EditSellerProfile_Successfull()
        {
            try
            {
                mockSellerManager.Setup(x => x.EditSellerProfile(It.IsAny<SellerDetails>())).ReturnsAsync(new bool());
                SellerDetails seller = new SellerDetails() { Sellerid = 809, Username = "priya", Password = "priyanka@", Companyname = "infosys", Gst = 47, Aboutcmpy = "gud", Address = "bangalore", Website = "www.infy.com", Email = "priya13@gmail.com", Mobileno = "9535678900" };
                var result = await sellerController.EditSellerProfile(seller) as OkResult;
                Assert.That(result, Is.Not.Null);
                Assert.That(result.StatusCode, Is.EqualTo(200));
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
                mockSellerManager.Setup(x => x.EditSellerProfile(It.IsAny<SellerDetails>())).ReturnsAsync(new bool());
                SellerDetails seller = new SellerDetails() { Sellerid = 890, Username = "priya", Password = "priyanka@", Companyname = "infosys", Gst = 47, Aboutcmpy = "gud", Address = "bangalore", Website = "www.infy.com", Email = "priya13@gmail.com", Mobileno = "9535678900" };
                var result = await sellerController.EditSellerProfile(seller) as OkResult;
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


