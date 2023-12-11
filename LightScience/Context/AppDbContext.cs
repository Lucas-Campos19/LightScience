using LightScience.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace LightScience.Context;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) :base(options)
    {
    }
    public DbSet<Lumen> Lumens { get; set; }

    public DbSet<Cutura> Cuturas { get; set; }

}
