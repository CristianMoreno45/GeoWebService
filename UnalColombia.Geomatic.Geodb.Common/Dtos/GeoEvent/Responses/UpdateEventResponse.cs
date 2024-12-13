using UnalColombia.Geomatic.Geodb.Common.Dtos;

namespace UnalColombia.Geomatic.Geodb.API.Dtos.GeoEvent.Responses
{
    public class UpdateEventResponse : Response<UpdateEventDataResponse>
    {

    }

    public class UpdateEventDataResponse
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

}
