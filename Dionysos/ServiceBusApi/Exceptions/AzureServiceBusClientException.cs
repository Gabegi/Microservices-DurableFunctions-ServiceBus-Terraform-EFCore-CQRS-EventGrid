using System;
using System.Runtime.Serialization;

namespace ServiceBusApi.Exceptions
{
    public class AzureServiceBusClientException: Exception
    {
        public AzureServiceBusClientException()
        {
        }

        public AzureServiceBusClientException(string message) : base(message)
        {
        }

        public AzureServiceBusClientException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AzureServiceBusClientException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
