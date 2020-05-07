using Moq;
using NUnit.Framework;
using SellerService.Entities;
using SellerService.Manager;
using SellerService.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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
                Seller seller = await sellerRepository.ViewSellerProfile(2);
                seller.Mobileno = "8561134678";
                await sellerRepository.EditSellerProfile(seller);
                Seller seller1 = await sellerRepository.ViewSellerProfile(2);
                var mock = new Mock<ISellerManager>();
                mock.Setup(x => x.ViewSellerProfile(2));
                Assert.AreSame(seller, seller1);
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
                Seller seller = await sellerRepository.ViewSellerProfile(7);
                seller.Mobileno = "9852364712";
                await sellerRepository.EditSellerProfile(seller);
                Seller seller1 = await sellerRepository.ViewSellerProfile(2);
                var mock = new Mock<ISellerManager>();
                mock.Setup(x => x.ViewSellerProfile(2));
                Assert.AreNotSame(seller, seller1);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }

        }

    }
}

   

    
