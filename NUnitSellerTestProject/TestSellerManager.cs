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
        public async Task SellerProfile_Successfull(int sid)
        {
            try
            {
                var result = await iSellerManager.ViewSellerProfile(sid);
                var mock = new Mock<ISellerManager>();
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
        [TestCase(404)]
        [TestCase(500)]
        [Description("testing seller Profile failure")]
        public async Task SellerProfile_UnSuccessfull(int sid)
        {
            try
            {
                var result = await iSellerManager.ViewSellerProfile(sid);
                var mock = new Mock<ISellerManager>();
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
        public async Task EditSellerProfile_Success()
        {
            try
            {
                //Seller seller = await iSellerManager.ViewSellerProfile(2);
                //seller.Mobileno = "8561134678";
                //await iSellerManager.EditSellerProfile(seller);
                //Seller seller1 = await iSellerManager.ViewSellerProfile(2);
                //var mock = new Mock<ISellerManager>();
                //mock.Setup(x => x.ViewSellerProfile(2));
                //Assert.AreSame(seller, seller1);
                Seller seller = new Seller() { Sid = 2 };
                var mock = new Mock<ISellerRepository>();
                mock.Setup(x => x.EditSellerProfile(seller)).ReturnsAsync(true);
                SellerManager sellerManager = new SellerManager(mock.Object);
                var result = sellerManager.EditSellerProfile(seller);
                Assert.NotNull(result);
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
                Seller seller = await iSellerManager.ViewSellerProfile(7);
                seller.Mobileno= "9852364712";
                await iSellerManager.EditSellerProfile(seller);
                Seller seller1= await iSellerManager.ViewSellerProfile(2);
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

   
