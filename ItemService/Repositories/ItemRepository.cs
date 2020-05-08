using ItemService.Entities;
using ItemService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItemService.Repositories
{
    public class ItemRepository
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
                items1.Id = items.Id;
                items1.Itemname = items.Itemname;
                items1.Price = items.Price;
                items1.Remarks = items.Remarks;
                items1.Stockno= items.Stockno;
                items1.Description = items.Description;

            }
            _context.Add(items1);
            var item = await _context.SaveChangesAsync();
            if (item > 0)
                return true;
            else
                return false;
        }

        public void DeleteItems(int id)
        {
            Items i = _context.Items.Find(id);
            _context.Remove(i);
            _context.SaveChanges();

        }

        public List<Items> ViewItems(int sid)
        {
            return _context.Items.Where(e => e.Sid == sid).ToList();
        }


    }
}

    

