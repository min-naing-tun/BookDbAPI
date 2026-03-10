using Microsoft.EntityFrameworkCore;
using BookDbApi.DbModels;

namespace BookDbApi
{
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options) { }

        public DbSet<Authors> Authors => Set<Authors>();
        public DbSet<Categories> Categories => Set<Categories>();
        public DbSet<Publishers> Publishers => Set<Publishers>();
        public DbSet<Books> Books => Set<Books>();
    }
}
