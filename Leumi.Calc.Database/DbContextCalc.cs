
using Leumi.Calc.Domain.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Leumi.Calc.Database
{
    public class DbContextCalc: DbContext
    {
        public DbContextCalc(DbContextOptions<DbContextCalc> dbContextOptions) : base(dbContextOptions)
        { }
        public DbSet<CalcValuesModel> CalcValues { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
    => options.UseQueryTrackingBehavior( QueryTrackingBehavior.TrackAll);
    }
}