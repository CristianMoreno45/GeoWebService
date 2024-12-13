using Microsoft.AspNetCore.Mvc;
using UnalColombia.Geomatic.Geodb.API.Dtos.GeoEvent.Requests;
using UnalColombia.Geomatic.Geodb.Common.API;
using UnalColombia.Geomatic.Geodb.Services.Handlers;

namespace UnalColombia.Geomatic.Geodb.API.Controllers
{
    /// <summary>
    /// Controller in charge of managing the API layer
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class EventLogController : CustomApiController<EventLogController>
    {
        /// <summary>
        /// Handler of the "Geo events" entity
        /// </summary>
        private readonly IGeoEventHandler _geoEventHandler;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="geoEventHandler">Handler of entity</param>
        /// <param name="logger">Logger</param>
        public EventLogController(IGeoEventHandler geoEventHandler, ILogger<EventLogController> logger) : base (logger)
        {
            _geoEventHandler = geoEventHandler;
        }

        /// <summary>
        /// Method in charge of extracting all the geo events where the "name" contains the search criteria
        /// </summary>
        /// <param name="request">Request</param>
        /// <returns>List of <see cref="GetEventResponse"/> </returns>
        [HttpPost]
        [Route("GetEventByName")]
        public async Task<IActionResult> GetEventByName([FromBody] GetEventRequest request)
        {
            // TODO: Validate inputs
            var task = _geoEventHandler.GetEventByName(request);
            return await Response(task);
        }

        /// <summary>
        /// Method in charge of extracting all the geo events where the "type" contains the search criteria
        /// </summary>
        /// <param name="request">Request</param>
        /// <returns>List of <see cref="GetEventResponse"/></returns>
        [HttpPost]
        [Route("GetEventByType")]
        public async Task<IActionResult> GetEventByType([FromBody] GetEventRequest request)
        {
            // TODO: Validate inputs
            var task = _geoEventHandler.GetEventByType(request);
            return await Response(task);
        }

        /// <summary>
        /// Method responsible for extracting a geo event by Id
        /// </summary>
        /// <param name="id">Geo event Id</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] long id)
        {
            var task = _geoEventHandler.GetEventById(id);
            return await Response(task);
        }

        /// <summary>
        /// Method responsible of creating a geo event
        /// </summary>
        /// <param name="request">Request</param>
        /// <returns>Geo event Id</returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddEventRequest request)
        {
            // TODO: Validate inputs
            var task = _geoEventHandler.AddEvent(request);
            return await Response(task);
        }

        /// <summary>
        /// Responsible method of updating an geo event.
        /// </summary>
        /// <param name="id">Geo event Id</param>
        /// <param name="request">Request</param>
        /// <returns>Geo entity updated</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] UpdateEventRequest request)
        {
            // TODO: Validate inputs
            var task = _geoEventHandler.UpdateEvent(id, request);
            return await Response(task);
        }

        /// <summary>
        /// Responsible method of deleting an geo event.
        /// </summary>
        /// <param name="id">Geo event Id</param>
        /// <returns>True: Operation successfull | False: Operation failed</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            // TODO: Validate inputs
            var task = _geoEventHandler.RemoveEvent(id);
            return await Response(task);
        }
    }
}
