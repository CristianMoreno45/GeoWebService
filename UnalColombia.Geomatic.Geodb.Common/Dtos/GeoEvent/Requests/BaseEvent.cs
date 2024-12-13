namespace UnalColombia.Geomatic.Geodb.API.Dtos.GeoEvent.Requests
{
    public class BaseEvent
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
