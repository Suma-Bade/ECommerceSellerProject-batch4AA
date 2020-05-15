using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Moq;
using Microsoft.EntityFrameworkCore;
using ItemService.Entities;
using ItemService.Repositories;
using ItemService.Models;
using System.Threading.Tasks;

namespace TestItemService
{
    [TestFixture]
    class TestItemRepository
    {
        IItemRepository itemRepository;
        DbContextOptionsBuilder<ECommerceDBContext> _builder;
        [SetUp]
        public void SetUp()
        {
            _builder = new DbContextOptionsBuilder<ECommerceDBContext>().EnableSensitiveDataLogging().UseInMemoryDatabase(Guid.NewGuid().ToString());
            ECommerceDBContext sellerContext = new ECommerceDBContext(_builder.Options);
            itemRepository = new ItemRepository(sellerContext);
            sellerContext.Items.Add(new Items { Itemid = 1, Itemname = "lg", Price = "10000", Description = "tv", Stockno = 123, Remarks = "good", Sellerid = 1 });
            sellerContext.SaveChanges();
        }
        [TearDown]
        public void TearDown()
        {
            itemRepository = null;
        }
        [Test]
        [TestCase(10, "pen", "100", 10, "stationary", "good", 2)]
        [Description("To test item is added to database")]
        public async Task TestAddItemSuccess(int itemid, string itemname, string price, int stocknumber, string description, string remarks, int sellerid)
        {
            try
            {
                var items = new ItemDetails { Itemid = itemid, Itemname = itemname, Price = price, Stockno = stocknumber, Description = description, Remarks = remarks, Sellerid = sellerid };
                var result = await itemRepository.AddItems(items);
                Assert.NotNull(result);
            }
            catch (Exception e)
            {

                Assert.Fail(e.InnerException.Message);

            }
        }
        [Test]
        [TestCase(10, "pen", 10, "stationary", "good", 2)]
        [Description("To test item is not added to database")]
        public async Task TestAddItemFail(int itemid, string itemname, string price, int stocknumber, string description, string remarks, int sellerid)
        {
            try
            {
                var items = new ItemDetails { Itemid = itemid, Itemname = itemname, Price = price, Stockno = stocknumber, Description = description, Remarks = remarks, Sellerid = sellerid };
                var result = await itemRepository.AddItems(items);
                Assert.NotNull(result);
            }
            catch (Exception e)
            {

                Assert.Fail(e.InnerException.Message);

            }
        }
        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [Description("to test whether details of an item are retrieved from database based on sellerid")]
        public void TestViewItemsSuccess(int sellerid)
        {
            try
            {
                var result = itemRepository.ViewItems(sellerid);
                Assert.IsNotNull(result);
            }
            catch (Exception e)
            {

                Assert.Fail(e.InnerException.Message);

            }

        }
        [Test]
        [TestCase(11)]
        [TestCase(20)]
        [Description("to test whether details of an item is not retrieved from database based on sellerid")]
        public void TestViewItemsFail(int sellerid)
        {
            try
            {
                var result = itemRepository.ViewItems(sellerid);
                Assert.IsNotNull(result);
            }
            catch (Exception e)
            {

                Assert.Fail(e.InnerException.Message);

            }

        }
        [Test]
        [TestCase(2, "pen", "1000", 10, "stationary", "good", 2)]
        [Description("to test whether an item is updated in database")]
        public async Task TestUpdateItemSuccess(int itemid, string itemname, string price, int stocknumber, string description, string remarks, int sellerid)
        {
            try
            {
                var items = new ItemDetails { Itemid = itemid, Itemname = itemname, Price = price, Stockno = stocknumber, Description = description, Remarks = remarks, Sellerid = sellerid };
                var result = await itemRepository.UpdateItems(items);
                Assert.IsNotNull(result);
                Assert.AreEqual(true, result);
            }
            catch (Exception e)
            {

                Assert.Fail(e.InnerException.Message);

            }


        }
        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [Description("to test whether an item is deleted from database")]
        public async Task TestDeleteItemsSuccess(int itemid)
        {
            try
            {
                var result = await itemRepository.DeleteItems(itemid);
                Assert.Null(result);
            }
            catch (Exception e)
            {

                Assert.Fail(e.InnerException.Message);

            }

        }

    }


}

