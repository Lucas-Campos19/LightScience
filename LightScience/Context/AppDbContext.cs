using LightScience.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace LightScience.Context;

public class AppDbContext: IdentityDbContext<IdentityUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) :base(options)
    {

    }
    public DbSet<Lux> Luxs { get; set; }
    public DbSet<Cutura> Cuturas { get; set; }

}
