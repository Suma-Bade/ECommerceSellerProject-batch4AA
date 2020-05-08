//using AccountService.Controllers;
//using AccountService.Entities;
//using AccountService.Manager;
//using AccountService.Models;
//using AccountService.Repositories;
//using NUnit.Framework;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading.Tasks;

//namespace NUnitTesting
//{
//    class TestAccountController
//    {
//        AccountController Controller;

//        [SetUp]
//        public void SetUp()
//        {
//            Controller = new AccountController(new AccountManager(new AccountRepository(new ECommerceDBContext())));

//        }
//        [Test]
//        [TestCase(9090,"prethi", "prethi88", "virtusa", 34, "good", "bangalore", "www.virtusa.com", "prethi@gmail.com", "9123479543")]
//        [Description("Test for SellerRegistration Success")]
//        public void TestSellerRegister_Success(int sid, string username, string password, string companyname, int gst, string aboutcmpy, string address, string website, string email, string mobileno)
//        {
//            try
//            {
//                var seller = new SellerRegister { Username = username, Password = password, Companyname = companyname, Aboutcmpy= aboutcmpy, Address = address, Website = website, Email = email,Mobileno= mobileno };
//                var res = Controller.SellerRegister(seller);

//                Assert.AreEqual(res.Result, true);
//            }
//            catch (Exception e)
//            {
//                Assert.Fail(e.Message);
//            }

//        }
//        [Test]
//        [TestCase("suma", "bade123")]
//        [Description("Seller Login Success")]
//        public void Test_Controller_SellerLogin_Success()
//        {
//            try
//            {
//                var result = Controller.SellerLogin("suma", "bade123");
//                Assert.IsNotNull(result);
//            }
//            catch (Exception e)
//            {
//                Assert.Fail(e.Message);
//            }
//        }
//        [Test]
//        [TestCase("sum", "suma123")]
//        [Description("Seller Login UnSuccess")]
//        public void Test_Controller_SellerLogin_UnSuccess()
//        {
//            try
//            {
//                var result = Controller.SellerLogin("asdf", "asdfg!");
//                Assert.IsNotNull(result);
//            }
//            catch (Exception e)
//            {
//                Assert.Fail(e.Message);
//            }


//        }



//    }



//}

