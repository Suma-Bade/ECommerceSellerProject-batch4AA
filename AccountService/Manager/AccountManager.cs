using AccountService.Extensions;
using AccountService.Entities;
using AccountService.Repositories;
using System;
using System.Threading.Tasks;
using AccountService.Models;


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
        }
        public async Task<SellerLogin> ValidateSeller(string username, string password)
        {
            SellerLogin seller1 = await _iAccountRepository.ValidateSeller(username, password);
            if (seller1 != null)
            {
                return seller1;
            }
            else
            {
                return null;
            }
        }
    }
}