using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SellerService.Entities;
using SellerService.Manager;
using SellerService.Models;
using SellerService.Repositories;

namespace SellerService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellerController : ControllerBase
    {
        private readonly ISellerManager _iSellerManager;

        public SellerController(ISellerManager iSellerManager)
        {
            _iSellerManager = iSellerManager;
        }
        [HttpPost]
        [Route("EditProfile")]
        public async Task<IActionResult> EditSellerProfile(SellerDetails seller)
        {
            return Ok(await _iSellerManager.EditSellerProfile(seller));

        }
        [HttpGet]
        [Route("Profile/{sellerid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ViewSellerProfile(int sellerid)
        {
            SellerDetails seller = await _iSellerManager.ViewSellerProfile(sellerid);
            if (seller == null)
                return Ok("Invalid User");
            else
            {
                return Ok(seller);
            }

        }
    }
}
