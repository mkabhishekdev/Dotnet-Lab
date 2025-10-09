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

        public async Task<Comment> CreateAsync(Comment commentModel)
        {
            await _applicationDbContext.Comments.AddAsync(commentModel);
            await _applicationDbContext.SaveChangesAsync();
            return commentModel;   
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