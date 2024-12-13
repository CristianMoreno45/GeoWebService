using System.Net;

namespace UnalColombia.Geomatic.Geodb.Common.Dtos
{
    public class HeaderResponse
    {
        /// <summary>
        /// Response Http Status Code
        /// </summary>
        public HttpStatusCode ResponseCode { get; set; } = HttpStatusCode.OK;

        /// <summary>
        /// Response message 
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Boolean request success indicator
        /// </summary>
        public bool Success
        {
            get
            {
                int responseCode = (int)ResponseCode;
                if (responseCode >= 200 && responseCode < 300)
                    return true;
                return false;
            }
        }

        /// <summary>
        /// Class constructor
        /// </summary>
        public HeaderResponse()
        {
            Message = "";
        }
    }
}
