
using Leumi.Calc.Domain.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Leumi.Calc.Database
{
    public class DbContextCalcMemory: DbContext
    {
        public DbContextCalcMemory(DbContextOptions<DbContextCalcMemory> dbContextOptions) : base(dbContextOptions)
        { }
        public DbSet<MemoryModel> Memory { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
    => options.UseQueryTrackingBehavior( QueryTrackingBehavior.TrackAll);
    }
}