using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class MidragContext: DbContext
    {
   
        public MidragContext(DbContextOptions<MidragContext> options) : base(options)
        {
        }

        public DbSet<Area> Areas { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Field> Fields { get; set; }
        public DbSet<JobType> jobTypes { get; set; }
        public DbSet<PhotosInRank> PhotosInRanks { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<ProviderInField> ProviderInFields { get; set; }
        public DbSet<ProviderInJobType> ProviderInJobTypes { get; set; }
        public DbSet<Rank> Ranks { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<SubField> SubFields { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
