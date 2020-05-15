using AccountService.Entities;
using AccountService.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AccountService.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ECommerceDBContext _context;
        public AccountRepository(ECommerceDBContext context)
        {
            _context = context;
        }

        /// <summary>
        /// To Add new seller to Seller table in database
        /// </summary>
        /// <param name="seller"></param>
        /// <returns></returns>
        public async Task<bool> SellerRegister(SellerRegister seller)
        {
            Seller seller1 = new Seller();
            if (seller != null)
            {
                seller1.Sellerid = seller.Sellerid;
                seller1.Username = seller.Username;
                seller1.Password = seller.Password;
                seller1.Gst = seller.Gst;
                seller1.Companyname = seller.Companyname;
                seller1.Aboutcmpy = seller.Aboutcmpy;
                seller1.Address = seller.Address;
                seller1.Website = seller.Website;
                seller1.Email = seller.Email;
                seller1.Mobileno = seller.Mobileno;

            };
            _context.Add(seller1);
            await _context.SaveChangesAsync();
            if ((seller1.Username != seller.Username) && (seller1.Email != seller.Email))
            {
                _context.Add(seller1);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }


        }
        /// <summary>
        /// To Check Paticular user is there or not
        /// </summary>
        /// <param name="uname"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public async Task<SellerLogin> ValidateSeller(string username, string password)
        {
            var user = await _context.Seller.SingleOrDefaultAsync(e => e.Username == username && e.Password == password);
            if (user != null)
            {
                return new SellerLogin
                {
                    Username = user.Username,
                    Password = user.Password,
                    sellerid = user.Sellerid,
                };
            }
            else
            {
                return null;
            }


        }
    }
}