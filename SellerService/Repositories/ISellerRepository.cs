using SellerService.Entities;
using SellerService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SellerService.Repositories
{
    public interface ISellerRepository
    {
        public Task<SellerDetails> ViewSellerProfile(int sid);
        public Task<bool> EditSellerProfile(SellerDetails seller);
    }
}
