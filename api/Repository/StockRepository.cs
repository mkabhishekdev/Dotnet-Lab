using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Interfaces;
using api.Data;
using api.Models;
using Microsoft.EntityFrameworkCore;
using api.Dtos.Stock;
using Microsoft.AspNetCore.Http.HttpResults;
using api.Helpers;

namespace api.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDBContext _applicationDBContext;
        public StockRepository(ApplicationDBContext dBContext)   // dependency-injection
        {
            _applicationDBContext = dBContext;
        }

        public async Task<Stock> CreateAsync(Stock stockModel)
        {
            await _applicationDBContext.Stocks.AddAsync(stockModel);
            await _applicationDBContext.SaveChangesAsync();
            return stockModel;
        }

        public async Task<Stock?> DeleteAsync(int id)
        {
            var stockModel = await _applicationDBContext.Stocks.FirstOrDefaultAsync(x => x.Id == id);
            if (stockModel == null)
            {
                return null;
            }
            _applicationDBContext.Stocks.Remove(stockModel);//'await' cannot be added here though you are hitting the database, Remove seems to be not a async function
            await _applicationDBContext.SaveChangesAsync();
            return stockModel;
        }

        
        public async Task<List<Stock>> GetAllAsync(QueryObject query)
        {
            var stocks = _applicationDBContext.Stocks.Include(c => c.Comments).ThenInclude(a => a.AppUser).AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.CompanyName))
            {
                stocks = stocks.Where(s => s.CompanyName.Contains(query.CompanyName));
            }

            if (!string.IsNullOrWhiteSpace(query.Symbol))
            {
                stocks = stocks.Where(s => s.Symbol.Contains(query.Symbol));
            }

            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if (query.SortBy.Equals("Symbol", StringComparison.OrdinalIgnoreCase))
                {
                    stocks = query.IsDescending ? stocks.OrderByDescending(s => s.Symbol) : stocks.OrderBy(s => s.Symbol);
                }
            }

            var skipNumber = (query.PageNumber - 1) * query.PageSize;  // Pagination concept

            return await stocks.Skip(skipNumber).Take(query.PageSize).ToListAsync();
        }


        public async Task<Stock?> GetByIdAsync(int id)
        {
            return await _applicationDBContext.Stocks.Include(c => c.Comments).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Stock?> GetBySymbolAsync(string symbol)
        {
            return await _applicationDBContext.Stocks.FirstOrDefaultAsync(s => s.Symbol == symbol);
        }

        public Task<bool> StockExists(int id)
        {
            return _applicationDBContext.Stocks.AnyAsync(s => s.Id == id);
        }

        public async Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto updateStockRequestDto)
        {
            var updateStockModel = await _applicationDBContext.Stocks.FirstOrDefaultAsync(x => x.Id == id);
            if (updateStockModel == null)
            {
                return null;
            }

            updateStockModel.Symbol = updateStockRequestDto.Symbol;
            updateStockModel.CompanyName = updateStockRequestDto.CompanyName;
            updateStockModel.Purchase = updateStockRequestDto.Purchase;
            updateStockModel.LastDividend = updateStockRequestDto.LastDividend;
            updateStockModel.Industry = updateStockRequestDto.Industry;
            updateStockModel.MarketCap = updateStockRequestDto.MarketCap;

            await _applicationDBContext.SaveChangesAsync();
            return updateStockModel;

        }
    }
}