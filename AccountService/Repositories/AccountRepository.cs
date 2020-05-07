using AccountService.Entities;
using AccountService.Extensions;
using AccountService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountService.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ECommerceDBContext _context;
        public AccountRepository(ECommerceDBContext context)
        {
            _context = context;
        }

        /// <summary>
        /// To Add new seller to Seller table in database
        /// </summary>
        /// <param name="seller"></param>
        /// <returns></returns>
        public async Task<bool> SellerRegister(SellerRegister seller)
        {
            //_context.Seller.Add(seller);
            //var user = await _context.SaveChangesAsync();
            //if(user>0)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
            Seller seller1 = new Seller();
            if (seller != null)
            {
                seller1.Sid = seller.Sid;
                seller1.Username = seller.Username;
                seller1.Password = seller.Password;
                seller1.Gst = seller.Gst;
                seller1.Companyname = seller.Companyname;
                seller1.Aboutcmpy = seller.Aboutcmpy;
                seller1.Address = seller.Address;
                seller1.Website = seller.Website;
                seller1.Email = seller.Email;
                seller1.Mobileno = seller.Mobileno;

            };
            _context.Add(seller1);
            var sellerId = await _context.SaveChangesAsync();
            if (sellerId > 0)
                return true;
            else
                return false;


        }
        /// <summary>
        /// To Check Paticular user is there or not
        /// </summary>
        /// <param name="uname"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public async Task<SellerLogin> ValidateSeller(string uname, string pwd)
        {
            var user = await _context.Seller.SingleOrDefaultAsync(e => e.Username == uname && e.Password == pwd);
            if (user != null)
            {
                return new SellerLogin
                {
                    Username = user.Username,
                    Password = user.Password,
                };
            }
            return null;

        }
    }
}