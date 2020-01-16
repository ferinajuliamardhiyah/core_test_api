using System;
using Microsoft.EntityFrameworkCore;
using core_test_api.Models;

namespace core_test_api.Database
{
    public class CoreDbContext : DbContext
    {
        public CoreDbContext(DbContextOptions<CoreDbContext> bebas) :base(bebas){}

        public DbSet<User> Users {get; set;}
        public DbSet<Post> Posts {get; set;}
        public DbSet<Comment> Comments {get; set;}
    }
}