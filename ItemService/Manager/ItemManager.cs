using ItemService.Entities;
using ItemService.Models;
using ItemService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItemService.Manager
{
    public class ItemManager:IItemManager
    {
        private readonly IItemRepository _itemRepository;
        public ItemManager(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;

        }

        public async Task<bool> AddItemsManager(ItemDetails obj)
        {
            bool item = await _itemRepository.AddItems(obj);
            return item;
        }

        public void DeleteItemsManager(int id)
        {
            _itemRepository.DeleteItems(id);

        }

        
        public List<Items> ViewItemsManager(int sellerid)
        {
            List<Items> items = _itemRepository.ViewItems(sellerid);
            return items;
        }

    }
}
    

