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
    public class CommentRepository : ICommentRepository
    {

        private readonly ApplicationDBContext _applicationDbContext;

        public CommentRepository(ApplicationDBContext dbContext)
        {
            _applicationDbContext = dbContext;
        }

        public async Task<List<Comment>> GetAllAsync()
        {
            return await _applicationDbContext.Comments.ToListAsync();
        }

        public async Task<Comment?> GetByIdAsync(int id)
        {
            return await _applicationDbContext.Comments.FindAsync(id);
        }
    }
}