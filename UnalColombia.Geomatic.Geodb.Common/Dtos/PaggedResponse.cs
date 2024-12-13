namespace UnalColombia.Geomatic.Geodb.Common.Dtos
{
    /// <summary>
    /// Show paginated results
    /// </summary>
    /// <typeparam name="T">Concrete class</typeparam>
    public class PaggedResponse<T>: Response<T>
    {
        /// <summary>
        /// Total number of records
        /// </summary>
        public int FullResultCount { get; set; }
        /// <summary>
        /// Determines if current page is the last page
        /// </summary>
        public bool HasMoreResults { get; set; }
    }


    public class PaggedRequest<T>
    {
        /// <summary>
        /// Concrete object
        /// </summary>
        public T? Request { get; set; }
        /// <summary>
        /// Determines which is the current page.
        /// </summary>
        public int CurrentPage { get; set; }
        /// <summary>
        /// Determines how many records each page has
        /// </summary>
        public int PageSize { get; set; }
    }
}
