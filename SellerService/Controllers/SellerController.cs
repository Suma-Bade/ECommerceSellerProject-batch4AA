using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SellerService.Entities;
using SellerService.Manager;
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
        public async Task<IActionResult> EditSellerProfile(Seller seller)
        {
            return Ok(await _iSellerManager.EditSellerProfile(seller));

        }
        [HttpGet]
        [Route("Profile/{sid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ViewSellerProfile(int sid)
        {
            Seller seller = await _iSellerManager.ViewSellerProfile(sid);
            if (seller == null)
                return Ok("Invalid User");
            else
            {
                return Ok(seller);
            }

        }
    }
}
