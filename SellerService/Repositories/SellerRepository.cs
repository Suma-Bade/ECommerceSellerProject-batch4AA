using SellerService.Entities;
using SellerService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SellerService.Repositories
{
    public class SellerRepository : ISellerRepository
    {
        private readonly ECommerceDBContext _context;
        public SellerRepository(ECommerceDBContext context)
        {
            _context = context;
        }
        public async Task<bool> EditSellerProfile(SellerDetails seller)
        {
            Seller seller1 = _context.Seller.Find(seller.Sellerid);
            if (seller1 != null)
            {
                seller1.Username = seller.Username;
                seller1.Password = seller.Password;
                seller1.Gst = seller.Gst;
                seller1.Companyname = seller.Companyname;
                seller1.Aboutcmpy = seller.Aboutcmpy;
                seller1.Address = seller.Address;
                seller1.Website = seller.Website;
                seller1.Email = seller.Email;
                seller1.Mobileno = seller.Mobileno;
                _context.Seller.Update(seller1);
                var user = await _context.SaveChangesAsync();
                if (user > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public async Task<SellerDetails> ViewSellerProfile(int sellerid)
        {
            Seller seller = await _context.Seller.FindAsync(sellerid);
            if (seller == null)
                return null;
            else
            {
                SellerDetails seller1 = new SellerDetails();
                seller1.Sellerid = seller.Sellerid;
                seller1.Username = seller.Username;
                seller1.Password = seller.Password;
                seller1.Gst = seller.Gst;
                seller1.Companyname = seller.Companyname;
                seller1.Aboutcmpy = seller.Aboutcmpy;
                seller1.Address = seller.Address;
                seller1.Website = seller.Website;
                seller1.Email = seller.Email;
                seller1.Mobileno = seller.Mobileno;
                return seller1;

            }
        }
    }
}