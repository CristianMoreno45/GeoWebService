
using NetTopologySuite.Geometries;

namespace UnalColombia.Geomatic.Geodb.Domain.AggregateModels
{
    /// <summary>
    /// Interface of entity
    /// </summary>
    public interface IGeoEvent
    {
        long GeoEventId { get; set; }
        Point Geom { get; set; }
        string Name { get; set; }
        string Type { get; set; }
    }
}
