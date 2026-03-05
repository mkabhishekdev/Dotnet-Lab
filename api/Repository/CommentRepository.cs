using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Helpers;
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

        public async Task<List<Comment>> GetAllAsync(CommentQueryObject commentQueryObject)
        {
            var comments = _applicationDbContext.Comments.Include(a => a.AppUser).AsQueryable();
            
            if(!string.IsNullOrWhiteSpace(commentQueryObject.Symbol))
            {
                comments = comments.Where(s => s.Stock.Symbol == commentQueryObject.Symbol);
            }
            
            if(commentQueryObject.IsDescending == true)
            {
                comments = comments.OrderByDescending(c => c.CreatedOn);    
            }

            return await comments.ToListAsync();
        }

        public async Task<Comment?> GetByIdAsync(int id)
        {
            return await _applicationDbContext.Comments.Include(a => a.AppUser).FirstOrDefaultAsync(c => c.Id == id);
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