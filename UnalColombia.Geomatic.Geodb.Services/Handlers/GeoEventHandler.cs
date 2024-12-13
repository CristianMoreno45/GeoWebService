using NetTopologySuite.Geometries;
using UnalColombia.Geomatic.Geodb.API.Dtos.GeoEvent.Requests;
using UnalColombia.Geomatic.Geodb.API.Dtos.GeoEvent.Responses;
using UnalColombia.Geomatic.Geodb.Domain.AggregateModels;

namespace UnalColombia.Geomatic.Geodb.Services.Handlers
{
    /// <summary>
    /// GeoEvent Entity Operations Handler
    /// </summary>
    public class GeoEventHandler : IGeoEventHandler
    {
        private readonly IGeoEventRepository _repository;
        public GeoEventHandler(IGeoEventRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetEventResponseById> GetEventById(long id)
        {
            var entity = await _repository.GetByIdAsync(id);
            var result = new BaseEvent()
            {
                Name = entity.Name.Trim(),
                Type = entity.Type.Trim(),
                Longitude = entity.Geom.X,
                Latitude = entity.Geom.Y
            };

            return new GetEventResponseById() { Data = result }; ;
        }
        public async Task<GetEventResponse> GetEventByName(GetEventRequest getRequest)
        {
            var counter = _repository.GetByFilter(x => x.Name.Contains(getRequest.Request ?? "")).Count();
            var result = _repository
                .GetByFilter(x => x.Name.Contains(getRequest.Request ?? ""))
                .Skip((getRequest.CurrentPage - 1) * getRequest.PageSize)
                .Take(getRequest.PageSize)
                .ToList();

            return BaseGetEvent(getRequest, counter, result);
        }

        public async Task<GetEventResponse> GetEventByType(GetEventRequest getRequest)
        {
            var counter = _repository.GetByFilter(x => x.Type.Contains(getRequest.Request ?? "")).Count();
            var result = _repository
                .GetByFilter(x => x.Type.Contains(getRequest.Request ?? ""))
                .Skip((getRequest.CurrentPage - 1) * getRequest.PageSize)
                .Take(getRequest.PageSize)
                .ToList();

            return BaseGetEvent(getRequest, counter, result);
        }

        private static GetEventResponse BaseGetEvent(GetEventRequest getRequest, int counter, List<GeoEvent> result)
        {
            List<BaseEvent> eventList = new List<BaseEvent>();
            result.ForEach(x =>
            {
                var item = new BaseEvent()
                {
                    Name = x.Name.Trim(),
                    Type = x.Type.Trim(),
                    Longitude = x.Geom.X,
                    Latitude = x.Geom.Y
                };
                eventList.Add(item);
            });
            return new GetEventResponse() { Data = eventList, FullResultCount = counter, HasMoreResults = getRequest.CurrentPage * getRequest.PageSize < counter };
        }

        public async Task<AddEventResponse> AddEvent(AddEventRequest geoEvent)
        {
            var result = await _repository.AddAsync(new GeoEvent()
            {
                Name = geoEvent.Name,
                Type = geoEvent.Type,
                Geom = new Point(geoEvent.Longitude, geoEvent.Latitude) { SRID = 4326 }
            });
            return new AddEventResponse() { Data = result.GeoEventId };
        }

        public async Task<bool> RemoveEvent(long id)
        {
            var result = await _repository.DeleteAsync(id);
            return result;
        }

        public async Task<UpdateEventResponse> UpdateEvent(long id, UpdateEventRequest geoEvent)
        {
            var entity = await _repository.GetByIdAsync(id);
            entity.Name = geoEvent.Name;
            entity.Type = geoEvent.Type;
            entity.Geom = new Point(geoEvent.Longitude, geoEvent.Latitude) { SRID = 4326 };
            GeoEvent result = await _repository.UpdateAsync(entity);
            return new UpdateEventResponse()
            {
                Data = new UpdateEventDataResponse()
                {
                    Name = result.Name,
                    Type = result.Type,
                    Longitude = result.Geom.X,
                    Latitude = result.Geom.Y
                }
            };
        }
    }
}
