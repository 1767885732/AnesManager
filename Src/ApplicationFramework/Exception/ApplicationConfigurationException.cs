using System;
using System.Configuration;

namespace ApplicationFramework.Exception
{
    public class ApplicationConfigurationException : ConfigurationErrorsException
    {
        public ApplicationConfigurationException() { }
        public ApplicationConfigurationException(string message) : base(message) { }
        public ApplicationConfigurationException(string message, System.Exception innerException) : base(message, innerException) { }
    }
}
