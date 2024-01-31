using Azure.Messaging.ServiceBus;
using System.Threading.Tasks;

namespace Infrastructure.AzureServiceBusClient
{
    public interface IAzureServiceBusClient
    {
        public Task SendOrder(ServiceBusMessage message, string nameSpaceName, string queueName);
    }
}
