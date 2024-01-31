using Azure.Messaging.ServiceBus;
using Common;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace Infrastructure.AzureServiceBusClient
{
    public class AzureServiceBusClient : IAzureServiceBusClient
    {
        private readonly ServiceBusClient _client;
        private ServiceBusSender _sender;
        private readonly ILogger<AzureServiceBusClient> _logger;

        public AzureServiceBusClient
            (
            ServiceBusSender sender,
            IOptions<AzureServiceBusOptions> options,
            ILogger<AzureServiceBusClient> logger
            )
        {
            var connectionString = options.Value.serviceBusConnectionString;

            _client = new ServiceBusClient(connectionString);
            _sender = sender;
            _logger = logger;
        }


        public async Task SendOrder(ServiceBusMessage message, string nameSpaceName, string queueName)
        {
            await using (_client)
            {
                _sender = _client.CreateSender(queueName);

                try
                {
                    await _sender.SendMessageAsync(message);
                }
                catch (Exception ex)
                {
                    _logger.LogInformation($"Exception: {ex}. Could not send message to Sevice Bus Queue: {queueName}, NameSpace: {nameSpaceName} for message: {message}.");
                }
            }
        }

    }
}
