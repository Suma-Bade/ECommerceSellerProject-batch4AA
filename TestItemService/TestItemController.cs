
using ItemService.Controllers;
using ItemService.Manager;
using ItemService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace TestItemService
{
    [TestFixture]
    public class TestItemController
    {
        private ItemController itemController;
        private Mock<IItemManager> mockItemManager;
        private Mock<ILogger<ItemController>> logger;
        [SetUp]
        public void Setup()
        {
            mockItemManager = new Mock<IItemManager>();
            logger = new Mock<ILogger<ItemController>>();
            itemController = new ItemController(mockItemManager.Object, logger.Object);
        }
        /// <summary>
        /// To Test For new item to add
        /// </summary>
        /// <returns></returns>
        [Test]
        [TestCase(1, "788", "Mobile", "Reliable", 98876, "Good", 1)]
        public async Task TestAddItems_valid_Returns_NotNull(int itemid, string price, string itemname, string description, int stockno, string remarks, int sellerid)
        {
            try
            {
                var itemDetails = new ItemDetails() { Itemid = itemid, Price = price, Itemname = itemname, Description = description, Stockno = stockno, Remarks = remarks, Sellerid = sellerid };
                mockItemManager.Setup(d => d.AddItems(It.IsAny<ItemDetails>())).ReturnsAsync(new bool());
                var result = await itemController.AddItems(itemDetails) as OkResult;
                Assert.That(result, Is.Not.Null);
                Assert.That(result.StatusCode, Is.EqualTo(200));

            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /// <summary>
        /// To Test For item to Update
        /// </summary>
        /// <returns></returns>
        [Test]
        [TestCase(1, "788", "Mobile", "Reliable", 98876, "Good", 1)]

        public async Task TestUpdateItems_valid_Returns_True(int itemid, string price, string itemname, string description, int stockno, string remarks, int sellerid)
        {
            try
            {
                var itemDetails = new ItemDetails() { Itemid = itemid, Price = price, Itemname = itemname, Description = description, Stockno = stockno, Remarks = remarks, Sellerid = sellerid };
                mockItemManager.Setup(d => d.UpdateItems(It.IsAny<ItemDetails>())).ReturnsAsync(new bool());
                var result = await itemController.UpdateItems(itemDetails) as OkResult;
                Assert.That(result, Is.Not.Null);
                Assert.That(result.StatusCode, Is.EqualTo(200));

            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /// <summary>
        /// To Test For item to Delete
        /// </summary>
        /// <returns></returns>
        [Test]
        [TestCase(1)]
        [Description("Test for SellerRegistration Success")]
        public void TestDeleteItem_valid_Returns_True(int itemid)
        {
            try
            {
                mockItemManager.Setup(x => x.DeleteItems(itemid)).ReturnsAsync(true);
                var result = itemController.DeleteItems(itemid);
                Assert.NotNull(result);

            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /// <summary>
        /// To Test For item to Delete
        /// </summary>
        /// <returns></returns>
        [Test]
        [TestCase(1)]
        [Description("Test for SellerRegistration Success")]
        public void TestDeleteItem_valid_Returns_False(int itemid)
        {
            try
            {
                mockItemManager.Setup(d => d.DeleteItems(itemid)).ReturnsAsync(false);
                var result = itemController.DeleteItems(itemid);
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
                mockItemManager.Setup(x => x.ViewItems(sellerid));
                var result = itemController.ViewItems(sellerid);
                Assert.NotNull(result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

    }
}
