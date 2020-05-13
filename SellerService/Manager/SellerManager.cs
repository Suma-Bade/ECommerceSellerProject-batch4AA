using SellerService.Entities;
using SellerService.Models;
using SellerService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SellerService.Manager
{
    public class SellerManager : ISellerManager
    {
        private readonly ISellerRepository _isellerRepository;
        public SellerManager(ISellerRepository isellerRepository)
        {
            _isellerRepository = isellerRepository;
        }
        public async Task<bool> EditSellerProfile(SellerDetails seller)
        {
            bool user = await _isellerRepository.EditSellerProfile(seller);
            if (user)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<SellerDetails> ViewSellerProfile(int sellerid)
        {
            SellerDetails seller = await _isellerRepository.ViewSellerProfile(sellerid);
            if (seller == null)
            {
                return null;
            }
            else
            {
                return seller;
            }
        }
    }
}


