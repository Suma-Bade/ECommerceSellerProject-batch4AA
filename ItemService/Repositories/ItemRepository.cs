using ItemService.Entities;
using ItemService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItemService.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly ECommerceDBContext _context;
        public ItemRepository(ECommerceDBContext context)
        {
            _context = context;
        }
        public async Task<bool> AddItems(ItemDetails items)
        {
            Items items1 = new Items();
            if (items != null)
            {
                items1.Itemid = items.Itemid;
                items1.Sellerid = items.Sellerid;
                items1.Itemname = items.Itemname;
                items1.Price = items.Price;
                items1.Remarks = items.Remarks;
                items1.Stockno = items.Stockno;
                items1.Description = items.Description;
                items1.Imagename = items.Imagename;

            }
            _context.Add(items1);
            var item = await _context.SaveChangesAsync();
            if (item > 0)
                return true;
            else
                return false;
        }

        public async Task<bool> DeleteItems(int itemid)
        {
            Items items = await _context.Items.FindAsync(itemid);
            if (items != null)
            {
                _context.Items.Remove(items);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }

        }
        public async Task<bool> UpdateItems(ItemDetails items)
        {
            Items items1 = _context.Items.Find(items.Itemid);
            if (items != null)
            {
                items1.Itemid = items.Itemid;
                items1.Sellerid = items.Sellerid;
                items1.Itemname = items.Itemname;
                items1.Price = items.Price;
                items1.Remarks = items.Remarks;
                items1.Stockno = items.Stockno;
                items1.Description = items.Description;
                items1.Imagename = items.Imagename;

            };
            _context.Items.Update(items1);
            var sellerId = await _context.SaveChangesAsync();
            if (sellerId > 0)
                return true;
            else
                return false;
        }
        public List<ItemDetails> ViewItems(int sellerid)
        {
            // return _context.Items.Where(e => e.Sellerid == sellerid).ToList();
            List<ItemDetails> items1 = new List<ItemDetails>();

            List<Items> items = _context.Items.Where(e => e.Sellerid == sellerid).ToList();
            foreach (Items item in items)
            {
                ItemDetails itemDetails = new ItemDetails();
                itemDetails.Itemid = item.Itemid;
                itemDetails.Itemname = item.Itemname;
                itemDetails.Price = item.Price;
                itemDetails.Remarks = item.Remarks;
                itemDetails.Stockno = item.Stockno;
                itemDetails.Description = item.Description;
                itemDetails.Sellerid = item.Sellerid;
                itemDetails.Imagename = item.Imagename;
                items1.Add(itemDetails);

            }
            return items1;
        }




    }
}



