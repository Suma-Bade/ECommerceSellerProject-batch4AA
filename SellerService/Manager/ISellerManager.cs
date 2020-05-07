using SellerService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SellerService.Manager
{
    public interface ISellerManager
    {
        public Task<bool> EditSellerProfile(Seller seller);
        public Task<Seller> ViewSellerProfile(int sid);

    }
}
