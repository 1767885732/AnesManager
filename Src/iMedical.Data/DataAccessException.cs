using System;
using System.Collections.Generic;
using System.Text;

namespace Wis.Anes.Data
{
    [Serializable]
    public class DataAccessException : Exception
    {
        public DataAccessException(string message, Exception innerException) : base(message, innerException)
        {
            Console.WriteLine(innerException.Message);
        }
    }
}
