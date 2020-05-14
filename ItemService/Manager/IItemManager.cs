using ItemService.Entities;
using ItemService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItemService.Manager
{
    public interface IItemManager
    {
        Task<bool> AddItems(ItemDetails items);
        public Task<bool> DeleteItems(int itemid);
        Task<bool> UpdateItems(ItemDetails items);
        List<ItemDetails> ViewItems(int sellerid);


    }
}
