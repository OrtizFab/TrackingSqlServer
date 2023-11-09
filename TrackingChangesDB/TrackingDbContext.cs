using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using TrackingChangesDB.Models;

namespace TrackingChangesDB
{
    public class TrackingDbContext: DbContext
    {
        public TrackingDbContext(DbContextOptions<TrackingDbContext> options): base(options)
        {
                
        }
        public DbSet<PostingCreations> PostingCreations { get; set; }
    }
}
