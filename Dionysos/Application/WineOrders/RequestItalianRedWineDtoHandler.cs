using AutoMapper;
using Azure.Messaging.ServiceBus;
using DTO;
using Infrastructure.AzureServiceBusClient;
using MediatR;
using Messages;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Text;

namespace Application.WineOrders
{
    public class RequestItalianRedWineDtoHandler : IRequestHandler<RequestItalianRedWineDto>
    {
        private readonly IAzureServiceBusClient _azureServiceBusClient;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public RequestItalianRedWineDtoHandler(
            IAzureServiceBusClient azureServiceBusClient,
            IConfiguration configuration,
            IMapper mapper
            )
        {
            _azureServiceBusClient = azureServiceBusClient;
            _configuration = configuration;
            _mapper = mapper;
        }

        public async Task Handle(RequestItalianRedWineDto requestDto, CancellationToken cancellationToken)
        {
            
            var request = _mapper.Map<RequestItalianRedWine>(requestDto);

            var messageBody = JsonConvert.SerializeObject(request);

            var message = new ServiceBusMessage(Encoding.UTF8.GetBytes(messageBody))
            {
                MessageId = request.RequestId,
                CorrelationId = request.RequestId + 1
            };

            await _azureServiceBusClient.SendOrder(message, _configuration["NameSpaceName"], _configuration["QueueName"]);
        }
    }

    
}