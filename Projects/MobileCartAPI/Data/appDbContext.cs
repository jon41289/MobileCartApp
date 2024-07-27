using System.Net.Http.Headers;
using Microsoft.EntityFrameworkCore;
// using MobileCartAPI.Models;
using ModelsLibrary;

namespace MobileCartAPI.Data{
    public class AppDbContext : DbContext{
        public AppDbContext(DbContextOptions options) : base(options){}

        // public DbSet<Cocktails> Cocktails{ get; set; }
        public DbSet<ModelsLibrary.Cocktails> Cocktails { get;set;}
    }    
}