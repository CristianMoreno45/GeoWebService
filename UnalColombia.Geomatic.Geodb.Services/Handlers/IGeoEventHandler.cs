using UnalColombia.Geomatic.Geodb.API.Dtos.GeoEvent.Requests;
using UnalColombia.Geomatic.Geodb.API.Dtos.GeoEvent.Responses;

namespace UnalColombia.Geomatic.Geodb.Services.Handlers
{
    public interface IGeoEventHandler
    {
        Task<GetEventResponseById> GetEventById(long id);
        Task<GetEventResponse> GetEventByName(GetEventRequest getRequest);
        Task<GetEventResponse> GetEventByType(GetEventRequest getRequest);
        Task<AddEventResponse> AddEvent(AddEventRequest geoEvent);
        Task<bool> RemoveEvent(long id);
        Task<UpdateEventResponse> UpdateEvent(long id, UpdateEventRequest geoEvent);
    }
}
