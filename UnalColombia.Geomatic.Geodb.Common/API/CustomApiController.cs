using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnalColombia.Geomatic.Geodb.Common.Dtos;
using UnalColombia.Geomatic.Geodb.Common.Exceptions;

namespace UnalColombia.Geomatic.Geodb.Common.API
{
    /// <summary>
    /// Base driver for the APIs of this project
    /// </summary>
    /// <typeparam name="TController">Object controller for logger</typeparam>
    public abstract class CustomApiController<TController> : ControllerBase
    {
        private readonly ILogger<TController> _logger;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger"></param>
        public CustomApiController(ILogger<TController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Standard return method
        /// </summary>
        /// <typeparam name="T">Request type</typeparam>
        /// <param name="action">Task to do</param>
        /// <returns>Action Result (OK|BadRequest|InternalServerError)</returns>
        protected async Task<IActionResult> Response<T>(Task<T> action)
        {
            try
            {
                var result = await action;
                return Ok(result);
            }
            catch (Exception ex) when (ex is BusinessRuleException)
            {
                _logger.LogError(ex, ex.Message);
                var result = new Response<T>();
                result.Header.ResponseCode = System.Net.HttpStatusCode.BadRequest;
                result.Header.Message = ex.Message;
                return BadRequest(result);
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex, ex.Message);
                var result = new Response<T>();
                result.Header.ResponseCode = System.Net.HttpStatusCode.InternalServerError;
                result.Header.Message = "An error has occurred, contact the administrator for more information.";
                return StatusCode(500,result);
            }
        }
    }
}
