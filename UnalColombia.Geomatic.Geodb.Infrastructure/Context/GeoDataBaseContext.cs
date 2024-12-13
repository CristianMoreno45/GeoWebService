using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using UnalColombia.Geomatic.Geodb.Domain.AggregateModels;
using UnalColombia.Geomatic.Geodb.Infrastructure.EntityConfigurations;

namespace UnalColombia.Geomatic.Geodb.Infrastructure.Context
{
    public class GeoDataBaseContext(DbContextOptions<GeoDataBaseContext> options) : DbContext(options)
    {
        public DbSet<GeoEvent> GeoEvent { get; set; }

        /// <summary>
        /// Migration settings are applied
        /// </summary>
        /// <param name="modelBuilder">Constructor del modelo</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // DB Behavior setting
            modelBuilder.ApplyConfiguration(new GeoEventEntityConfiguration());


        }
    }
}
