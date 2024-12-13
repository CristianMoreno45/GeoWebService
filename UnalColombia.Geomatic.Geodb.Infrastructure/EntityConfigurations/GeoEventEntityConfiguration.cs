using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnalColombia.Geomatic.Geodb.Domain.AggregateModels;

namespace UnalColombia.Geomatic.Geodb.Infrastructure.EntityConfigurations
{
    /// <summary>
    /// Class with entity configurations
    /// </summary>
    public class GeoEventEntityConfiguration : IEntityTypeConfiguration<GeoEvent>
    {
        /// <summary>
        /// Configure entity relationships and properties
        /// </summary>
        /// <param name="entityConfiguration">Entity to configure</param>
        public void Configure(EntityTypeBuilder<GeoEvent> entityConfiguration)
        {
            //The name of the table and the schema are defined
            entityConfiguration.ToTable("geoEvent");
            entityConfiguration.HasIndex(a => a.GeoEventId);
            entityConfiguration.Property(e => e.GeoEventId).HasColumnName("geo_eventid");
            entityConfiguration.Property(e => e.Name).HasColumnName("name_event");
            entityConfiguration.Property(e => e.Type).HasColumnName("type_event");
            entityConfiguration.Property(e => e.Geom).HasColumnName("geom");


        }
    }


}
