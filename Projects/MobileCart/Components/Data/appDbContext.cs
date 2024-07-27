using Microsoft.EntityFrameworkCore;

namespace MobileCart.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options){}

    // public DbSet<Cocktails> Cocktails {}

}