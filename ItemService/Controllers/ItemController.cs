using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ItemService.Manager;
using ItemService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ItemService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemManager _manager;
        private readonly ILogger<ItemController> _logger;
        public ItemController(IItemManager manager, ILogger<ItemController> logger)
        {
            _manager = manager;
            _logger = logger;
        }
        [HttpPost]
        [Route("AddItem")]
        public async Task<IActionResult> AddItems(ItemDetails item)
        {
            _logger.LogInformation("AddItem");
            if (item is null)
            {
                return BadRequest("Item is null");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                await _manager.AddItems(item);
                return Ok();
            }
        }
        [HttpPut]
        [Route("UpdateItem")]
        public async Task<IActionResult> UpdateItems(ItemDetails item)
        {
            _logger.LogInformation("UpdateItem");
            if (item is null)
            {
                return BadRequest("Item is null");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                await _manager.UpdateItems(item);
                return Ok();
            }
            //return Ok(await _manager.UpdateItems(item));



        }
        [HttpDelete]
        [Route("DeleteItem/{itemid}")]

        public async Task<IActionResult> DeleteItems(int itemid)
        {

            return Ok(await _manager.DeleteItems(itemid));
        }
        [HttpGet]
        [Route("ViewItems/{sellerid}")]

        public IActionResult ViewItems(int sellerid)
        {
            return Ok(_manager.ViewItems(sellerid));
            throw new Exception("Exception while retrieving the items from the storage.");

        }
    }
}


