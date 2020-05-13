using AccountService.Extensions;
using AccountService.Entities;
using AccountService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountService.Models;
using System.Web.Http.Results;


namespace AccountService.Manager
{
    public class AccountManager : IAccountManager
    {
        private readonly IAccountRepository _iAccountRepository;

        public AccountManager(IAccountRepository iAccountRepository)
        {
            _iAccountRepository = iAccountRepository;
        }
        public async Task<bool> SellerRegister(SellerRegister seller)
        {
            bool user = await _iAccountRepository.SellerRegister(seller);
            return user;
            //remove all try-catch blocks from all layers
        }

        public Task SellerRegister(Seller seller)
        {
            throw new NotImplementedException();
        }

        public async Task<SellerLogin> ValidateSeller(string username, string password)
        {
            var seller1 = await _iAccountRepository.ValidateSeller(username, password);
            if (seller1.Username == username && seller1.Password == password)
            {
                return seller1;
            }
            else
            {
                Console.WriteLine("Invalid");
                return seller1;
            }

        }
    }
}