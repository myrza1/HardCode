using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HardCode.Models;

namespace HardCode.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<HardCode.Models.Tayar>? Tayar { get; set; }
        public DbSet<HardCode.Models.JekeSostav>? JekeSostav { get; set; }
    }
}