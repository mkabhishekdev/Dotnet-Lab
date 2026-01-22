using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Extensions;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/userstock")]
    [ApiController]
    public class UserStockController : ControllerBase
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly IStockRepository _stockRepo;

        private readonly IUserStockRepository _userStockRepo;

        public UserStockController(UserManager<AppUser> userManager,
        IStockRepository stockRepo, IUserStockRepository userStockRepo)
        {
            _userManager = userManager;
            _stockRepo = stockRepo;
            _userStockRepo = userStockRepo;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUserStock()
        {
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);
            var userStock = await _userStockRepo.GetUserStock(appUser);
            return Ok(userStock);
        }
        
    }
}