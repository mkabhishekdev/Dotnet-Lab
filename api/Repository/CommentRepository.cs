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

        public async Task<Comment?> DeleteAsync(int id)
        {
            var commentModel = await _applicationDbContext.Comments.FirstOrDefaultAsync(x => x.Id == id);

            if (commentModel == null)
            {
                return null;
            }

            _applicationDbContext.Comments.Remove(commentModel);
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

        public async Task<Comment?> UpdateAsync(int id, Comment commentModel)
        {
            var existingComment = await _applicationDbContext.Comments.FindAsync(id);

            if (existingComment == null)
            {
                return null;
            }

            existingComment.Title = commentModel.Title;
            existingComment.Content = commentModel.Content;

            await _applicationDbContext.SaveChangesAsync();

            return existingComment;
        }
    }
}