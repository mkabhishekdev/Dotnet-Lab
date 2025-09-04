using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Interfaces;
using api.Data;

namespace api.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDBContext _applicationDBContext;
        public StockRepository(ApplicationDBContext dBContext)   // dependency-injection
        {
            _applicationDBContext = dBContext;
        }

        public Task<List<Stock>> GetAllAsync()
        {
            return _applicationDBContext.Stocks.ToListAsync();
        }


        
    }
}