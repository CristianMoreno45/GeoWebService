using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnalColombia.Geomatic.Geodb.Common.Exceptions
{
    /// <summary>
    /// Exception generated in the database layer
    /// </summary>
    /// <typeparam name="T">Entity type</typeparam>
    public class DataBaseException<T>: Exception
    {
        private readonly T? _entity;

       
        public DataBaseException()
        {
        }
        public DataBaseException(T entity, TypeOperation operation, Exception inner) : base($"An error occurred when the system attempted to perform the operation {operation} with the following information {Newtonsoft.Json.JsonConvert.SerializeObject(entity)}", inner)
        {
            _entity = entity;
        }

        public DataBaseException(string message) : base(message)
        {

        }

        public DataBaseException(string message, Exception inner) : base(message, inner)
        {
        }
    }
    public enum TypeOperation
    {
        DELETE,
        CREATE,
        UPDATE,
        SELECT

    }
}
