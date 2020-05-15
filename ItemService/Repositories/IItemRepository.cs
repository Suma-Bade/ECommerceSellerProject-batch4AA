using ItemService.Entities;
using ItemService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItemService.Repositories
{
    public interface IItemRepository
    {
        public Task<bool> AddItems(ItemDetails items);
        public Task<bool> DeleteItems(int itemid);
        public Task<bool> UpdateItems(ItemDetails items);

        public List<ItemDetails> ViewItems(int sellerid);
   



    }
}
