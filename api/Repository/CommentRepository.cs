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
        private readonly ICommentRepository _commentRepo;
        private readonly ApplicationDBContext _applicationDbContext;

        public CommentRepository(ApplicationDBContext dbContext, ICommentRepository commentRepository)
        {
            _applicationDbContext = dbContext;
            _commentRepo = commentRepository;
        }

        public async Task<List<Comment>> GetAllAsync()
        {
            return await _applicationDbContext.Comments.ToListAsync();
        }

        
    }
}