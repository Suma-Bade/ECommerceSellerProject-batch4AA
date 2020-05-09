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
        List<Items> ViewItemsManager(int sid);
        Task<bool> AddItemsManager(ItemDetails obj);
        public void DeleteItemsManager(int id);
       
    }
}
