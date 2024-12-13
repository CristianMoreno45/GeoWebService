
using NetTopologySuite.Geometries;

namespace UnalColombia.Geomatic.Geodb.Domain.AggregateModels
{
    /// <summary>
    /// Domain entity (DDD)
    /// </summary>
    public class GeoEvent : IGeoEvent
    {
        public long GeoEventId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public Point Geom { get; set; }
    }
}
