using Microsoft.EntityFrameworkCore;
using src.Models;

namespace src.Data{
    public class AppContext : DbContext{
        public AppContext(DbContextOptions<Data.AppContext> options) : base(options){}

        public DbSet<User> Users{get; set;}
        public DbSet<Organisation> Organisations{get; set;}
    }
}