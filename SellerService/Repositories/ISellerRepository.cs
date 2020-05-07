using SellerService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SellerService.Repositories
{
    public interface ISellerRepository
    {
        public Task<Seller> ViewSellerProfile(int sid);
        public Task<bool> EditSellerProfile(Seller seller);
    }
}
