using ItemService.Entities;
using ItemService.Models;
using ItemService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItemService.Manager
{
    public class ItemManager : IItemManager
    {
        private readonly IItemRepository _itemRepository;
        public ItemManager(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;

        }

        public async Task<bool> AddItems(ItemDetails items)
        {
            bool item = await _itemRepository.AddItems(items);
            return item;
        }

        public async Task<bool> DeleteItems(int itemid)
        {
            bool result = await _itemRepository.DeleteItems(itemid);
            return result;

        }
        public async Task<bool> UpdateItems(ItemDetails items)
        {
            bool item = await _itemRepository.UpdateItems(items);
            return item;
        }
        public List<ItemDetails> ViewItems(int sellerid)
        {
            List<ItemDetails> items = _itemRepository.ViewItems(sellerid);
            return items;
        }

    }
}


