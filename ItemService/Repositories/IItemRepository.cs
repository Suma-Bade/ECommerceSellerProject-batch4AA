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
        public void DeleteItems(int id);
        public List<Items> ViewItems(int sid);

    }
}
