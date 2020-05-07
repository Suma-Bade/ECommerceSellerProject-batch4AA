using SellerService.Entities;
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
        public async Task<bool> EditSellerProfile(Seller seller)
        {
            _context.Update(seller);
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

        public async Task<Seller> ViewSellerProfile(int sid)
        {
            Seller seller = await _context.Seller.FindAsync(sid);
            if (seller == null)
                return null;
            else
                return seller;
        }
    }
}