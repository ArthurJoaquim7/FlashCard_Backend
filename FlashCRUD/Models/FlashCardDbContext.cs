using Microsoft.EntityFrameworkCore;

namespace FlashCRUD.Models
{
    public class FlashCardDbContext : DbContext
    {
        public FlashCardDbContext(DbContextOptions<FlashCardDbContext> options) : base(options)
        {
        }

        public DbSet<FlashCard> FlashCards { get; set; }
    }
}
