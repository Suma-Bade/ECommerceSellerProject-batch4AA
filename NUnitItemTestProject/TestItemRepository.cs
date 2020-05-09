using ItemService.Entities;
using ItemService.Repositories;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitItemTestProject
{
    public class TestItemRepository
    {
        IItemRepository itemRepository;

        [SetUp]
        public void SetUp()
        {
            itemRepository = new ItemRepository(new ECommerceDBContext());
        }

        [TearDown]
        public void TearDown()
        {
            itemRepository = null;
        }
        /// <summary>
        /// Testing view items functionality
        /// </summary>
        [Test]
        [TestCase(2)]
        [TestCase(7)]
        [Description("testing view items functionality")]
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
    }
}
