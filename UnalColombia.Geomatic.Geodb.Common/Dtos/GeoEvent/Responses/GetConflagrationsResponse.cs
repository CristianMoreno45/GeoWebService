using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnalColombia.Geomatic.Geodb.Common.Dtos.GeoEvent.Responses
{
    public class GetConflagrationsResponse
    {
       public List<GeoEventResponse> Events {  get; set; }
    }

    public class GeoEventResponse
    {
        public string Name { get; set; }
        public string Type { get; set; }
    }
}
