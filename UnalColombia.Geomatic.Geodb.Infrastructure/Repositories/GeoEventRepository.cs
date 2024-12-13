using Microsoft.EntityFrameworkCore;
using UnalColombia.Geomatic.Geodb.Common.Infrastructure;
using UnalColombia.Geomatic.Geodb.Domain.AggregateModels;
using UnalColombia.Geomatic.Geodb.Infrastructure.Context;

namespace UnalColombia.Geomatic.Geodb.Infrastructure.Repositories
{
    /// <summary>
    /// Class in charge of managing the data access layer
    /// </summary>
    public class GeoEventRepository: PostgresRepository<GeoEvent, GeoDataBaseContext>, IGeoEventRepository
    {
        public GeoEventRepository(GeoDataBaseContext context): base (context)
        {
            
        }
      
    }
}
