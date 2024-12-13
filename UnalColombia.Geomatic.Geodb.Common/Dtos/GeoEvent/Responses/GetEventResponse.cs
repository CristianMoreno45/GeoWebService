using UnalColombia.Geomatic.Geodb.API.Dtos.GeoEvent.Requests;
using UnalColombia.Geomatic.Geodb.Common.Dtos;

namespace UnalColombia.Geomatic.Geodb.API.Dtos.GeoEvent.Responses
{
    public class GetEventResponse : PaggedResponse<List<BaseEvent>>
    { 
    }

    public class GetEventResponseById : Response<BaseEvent>
    {
    }
}
