using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class UserStockRepository : IUserStockRepository
    {
        private readonly ApplicationDBContext _context;
        public UserStockRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<UserStock> CreateAsync(UserStock userStock)
        {
            await _context.UserStocks.AddAsync(userStock);
            await _context.SaveChangesAsync();
            return userStock;
        }

        public async Task<List<Stock>> GetUserStock(AppUser user)
        {
            return await _context.UserStocks.Where(u => u.AppUserId == user.Id)
            .Select(stock => new Stock
            {
                Id = stock.StockId,
                Symbol = stock.Stock.Symbol,
                CompanyName = stock.Stock.CompanyName,
                Purchase = stock.Stock.Purchase,
                LastDividend = stock.Stock.LastDividend,
                Industry = stock.Stock.Industry,
                MarketCap = stock.Stock.MarketCap
            }).ToListAsync();
        }
         
    }
}