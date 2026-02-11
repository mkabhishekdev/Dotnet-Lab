using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface IUserStockRepository
    {
        Task<List<Stock>> GetUserStock(AppUser user);
        Task<UserStock> CreateAsync(UserStock userStock);
        Task<UserStock> DeleteUserStock(AppUser appUser, string symbol);
    }
}