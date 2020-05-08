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

namespace NUnitSellerTestProject
{
    public class TestSellerRepository
    {
        ISellerRepository sellerRepository;

        [SetUp]
        public void SetUp()
        {
            sellerRepository = new SellerRepository(new ECommerceDBContext());
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
        public async Task SellerProfile_Successfull(int sid)
        {
            try
            {
                var result = await sellerRepository.ViewSellerProfile(sid);
                var mock = new Mock<ISellerRepository>();
                mock.Setup(x => x.ViewSellerProfile(sid));
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
        public async Task SellerProfile_UnSuccessfull(int sid)
        {
            try
            {
                var result = await sellerRepository.ViewSellerProfile(sid);
                var mock = new Mock<ISellerRepository>();
                mock.Setup(x => x.ViewSellerProfile(sid));
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
                SellerDetails seller = new SellerDetails() { Sid = 1234, Username = "manaswi", Password = "manaswi@", Companyname = "accenture", Gst = 78, Aboutcmpy = "good", Address = "mumbai", Website = "www.accenture.com", Email = "manaswi@gmail.com", Mobileno = "9478654567" };
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

                SellerDetails seller = new SellerDetails() { Sid = 507, Username = "manaswi", Password = "manaswi@", Companyname = "accenture", Gst = 78, Aboutcmpy = "good", Address = "mumbai", Website = "www.accenture.com", Email = "manaswi@gmail.com", Mobileno = "9478654567" };
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

   

    
