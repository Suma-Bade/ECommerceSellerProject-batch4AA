using ItemService.Entities;
using ItemService.Manager;
using ItemService.Models;
using ItemService.Repositories;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TestItemService
{
    public class TestItemManager
    {
        IItemManager itemManager;
        private Mock<IItemRepository> mockItemManager;
        [SetUp]
        public void SetUp()
        {
            mockItemManager = new Mock<IItemRepository>();
            itemManager = new ItemManager(mockItemManager.Object);

        }
        [TearDown]
        public void TearDown()
        {
            itemManager = null;
        }
        /// <summary>
        /// Testing for adding new item success
        /// </summary>
        [Test]
        [TestCase(987, "8787", "Tv", "42inchLED", 6, "no", 3)]
        [Description("Test for AddItems Success")]
        public async Task TestAddItem_Success(int id, string price, string name, string description, int stock, string remarks, int sid)
        {
            try
            {
                var item = new ItemDetails
                {
                    Itemid = id,
                    Price = price,
                    Itemname = name,
                    Description = description,
                    Stockno = stock,
                    Remarks = remarks,
                    Sellerid = sid
                };
                var mock = new Mock<IItemRepository>();
                mock.Setup(x => x.AddItems(item)).ReturnsAsync(true);
                ItemManager imanager = new ItemManager(mock.Object);
                var result = await imanager.AddItems(item);
                Assert.IsNotNull(result, "test method failed SellerRegister method is null");
                Assert.AreEqual(true, result);

            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }

        }
        /// <summary>
        /// Testing for adding new item unsuccess
        /// </summary>
        [Test]
        [TestCase(987, "8787", "Tv", "42inchLED", 6, "no", 3)]
        [Description("Test for AddItems Success")]
        public async Task TestAddItem_UnSuccess(int id, string price, string name, string description, int stock, string remarks, int sid)
        {

            try
            {
                var item = new ItemDetails
                {
                    Itemid = id,
                    Price = price,
                    Itemname = name,
                    Description = description,
                    Stockno = stock,
                    Remarks = remarks,
                    Sellerid = sid
                };
                var mock = new Mock<IItemRepository>();
                mock.Setup(x => x.AddItems(item)).ReturnsAsync(false);
                ItemManager imanager = new ItemManager(mock.Object);
                var result = await imanager.AddItems(item);
                Assert.IsNotNull(result, "test method failed SellerRegister method is null");
                Assert.AreEqual(false, result);

            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }

        }
        /// <summary>
        /// Testing for ViewItem Success
        /// </summary>
        [Test]
        [TestCase(2)]
        [Description("testing View Items")]
        public void ViewItemsSuccess(int sellerid)
        {
            try
            {
                List<ItemDetails> item = new List<ItemDetails>();
                var mock = new Mock<IItemRepository>();
                mock.Setup(x => x.ViewItems(sellerid)).Returns(item);
                ItemManager itemManager = new ItemManager(mock.Object);
                var result = itemManager.ViewItems(sellerid);
                Assert.NotNull(result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /// <summary>
        /// Testing for ViewItem Success
        /// </summary>
        [Test]
        [TestCase(98)]
        [Description("testing View Items")]
        public void ViewItemsUnSuccess(int sellerid)
        {
            try
            {

                var mock = new Mock<IItemRepository>();
                mock.Setup(x => x.ViewItems(sellerid));
                ItemManager itemManager = new ItemManager(mock.Object);
                var result = itemManager.ViewItems(sellerid);
                Assert.IsNull(result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [Test]
        [Description("testing item edit Profile")]
        public async Task UpdateItems_Success()
        {
            try
            {
                var item = new ItemDetails
                {
                    Itemid = 2,
                    Price = "987987",
                    Itemname = "Samsung",
                    Description = "Tv",
                    Stockno = 76,
                    Remarks = "no",
                    Sellerid = 4
                };
                var mock = new Mock<IItemRepository>();
                mock.Setup(x => x.UpdateItems(item)).ReturnsAsync(true);
                ItemManager itemManager = new ItemManager(mock.Object);
                var result = await itemManager.UpdateItems(item);
                Assert.IsNotNull(result);
                Assert.AreEqual(true, result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [Test]
        [Description("testing item edit unsucess")]
        public async Task UpdateItems_UnSuccess()
        {
            try
            {
                var item = new ItemDetails
                {
                    Itemid = 2,
                    Price = "987987",
                    Itemname = "Samsung",
                    Description = "Tv",
                    Stockno = 76,
                    Remarks = "no",
                    Sellerid = 4
                };
                var mock = new Mock<IItemRepository>();
                mock.Setup(x => x.UpdateItems(item)).ReturnsAsync(false);
                ItemManager itemManager = new ItemManager(mock.Object);
                var result = await itemManager.UpdateItems(item);
                Assert.IsNotNull(result);
                Assert.AreEqual(false, result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [Test]
        [TestCase(2)]
        [Description("to test whether an item is deleted ")]
        public async Task TestDeleteItemsSuccess(int itemid)
        {
            try
            {
                var mock = new Mock<IItemRepository>();
                mock.Setup(x => x.DeleteItems(itemid)).ReturnsAsync(true);
                ItemManager itemManager = new ItemManager(mock.Object);
                var result = await itemManager.DeleteItems(itemid);
                Assert.AreEqual(true, result);
            }
            catch (Exception e)
            {

                Assert.Fail(e.InnerException.Message);

            }

        }
        [Test]
        [TestCase(62)]
        [Description("to test whether an item is deleted ")]
        public async Task TestDeleteItemsUnSuccess(int itemid)
        {
            try
            {
                var mock = new Mock<IItemRepository>();
                mock.Setup(x => x.DeleteItems(itemid)).ReturnsAsync(false);
                ItemManager itemManager = new ItemManager(mock.Object);
                var result = await itemManager.DeleteItems(itemid);
                Assert.AreEqual(false, result);
            }
            catch (Exception e)
            {

                Assert.Fail(e.InnerException.Message);

            }

        }






    }
}
