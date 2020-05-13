using SellerService.Entities;
using SellerService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SellerService.Manager
{
    public interface ISellerManager
    {
        public Task<bool> EditSellerProfile(SellerDetails seller);
        public Task<SellerDetails> ViewSellerProfile(int sellerid);

    }
}
