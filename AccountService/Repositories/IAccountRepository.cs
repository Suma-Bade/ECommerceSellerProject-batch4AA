using AccountService.Entities;
using AccountService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountService.Repositories
{
    public interface IAccountRepository
    {
        Task<SellerLogin> ValidateSeller(string username, string password);
        Task<bool> SellerRegister(SellerRegister seller);
    }
}
