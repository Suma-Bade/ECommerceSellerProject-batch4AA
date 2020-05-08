using SellerService.Entities;
using SellerService.Models;
using SellerService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SellerService.Manager
{
    public class SellerManager:ISellerManager
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

        public async Task<SellerDetails> ViewSellerProfile(int sid)
        {
            SellerDetails seller = await _isellerRepository.ViewSellerProfile(sid);
            if (seller == null)
            {
                return null;
            }
            else
            {
                SellerDetails seller1 = new SellerDetails();
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
    

