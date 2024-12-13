namespace UnalColombia.Geomatic.Geodb.Common.Exceptions
{
    /// <summary>
    /// Exception generated in the business layer
    /// </summary>
    public class BusinessRuleException : Exception
    {
        public BusinessRuleException()
        {
        }
        public BusinessRuleException(string message) : base(message)
        {

        }
        public BusinessRuleException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
