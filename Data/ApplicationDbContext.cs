using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TriviaLink.Models;

namespace TriviaLink.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<TriviaLink.Models.Game> Game { get; set; } = default!;
        public DbSet<TriviaLink.Models.Slide> Slide { get; set; } = default!;
    }
}