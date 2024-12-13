namespace UnalColombia.Geomatic.Geodb.Common.Dtos
{
    public class Response<TData>
    {
        /// <summary>
        /// General status of the request (internal)
        /// </summary>
        private HeaderResponse _header;

        /// <summary>
        /// General status of the request
        /// </summary>
        public HeaderResponse Header
        {
            get
            {
                if (_header == null)
                    _header = new HeaderResponse();
                return _header;
            }
            set
            {
                _header = value;
            }
        }

        /// <summary>
        /// Concreate data response
        /// </summary>
        public TData? Data { get; set; }

        /// <summary>
        /// Class constructor
        /// </summary>
        public Response()
        {
            _header = new HeaderResponse();
        }
    }
}
