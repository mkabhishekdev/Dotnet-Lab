using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using api.Models;


namespace api.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dBContextOptions) : base(dBContextOptions)
        {

        }

        public DbSet<Stock> Stock { get; set; }
        public DbSet<Comment> Comment { get; set; }

    }
}