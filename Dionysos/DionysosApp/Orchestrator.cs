using System.Threading.Tasks;
using Application.Messages;
using MediatR;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace DionysosApp
{
    public class Orchestrator
    {
        private readonly IConfiguration _configuration;
        private readonly IMediator _mediator;
        private int _customerId;

        public Orchestrator(IConfiguration configuration, IMediator mediator)
        {
            _configuration = configuration;
            _mediator = mediator;
        }

        [FunctionName("ProcessNewOrderClient")]
        public async Task ProcessNewOrder(
            [ServiceBusTrigger("dionysos-servicebus-queue", Connection = "serviceBusConnectionString")] RequestItalianRedWine message,
            [DurableClient] IDurableOrchestrationClient starter,
            ILogger log)
        {
            log.LogInformation($"{nameof(ProcessNewOrder)} received message: {message}");

            _customerId = message.CustomerId;

            string instanceId = await starter.StartNewAsync(nameof(ProcessItalianRedWineOrderOrchestrator), message);

            log.LogInformation($"client {nameof(ProcessNewOrder)} sent message to orchestrator: {message}");
        }

        [FunctionName("ProcessItalianRedWineOrderOrchestrator")]
        public async Task ProcessItalianRedWineOrderOrchestrator(
            [OrchestrationTrigger] IDurableOrchestrationContext context,
            ILogger log)
        {
            var message = context.GetInput<RequestItalianRedWine>();

            log.LogInformation($"{nameof(ProcessItalianRedWineOrderOrchestrator)} received message: {message}");

            await context.CallActivityAsync<int>(nameof(CreateOrderItalianRedWine), message);
            await context.CallActivityAsync(nameof(CheckInventory), message);

        }

        [FunctionName(nameof(CreateOrderItalianRedWine))]
        public async Task CreateOrderItalianRedWine([ActivityTrigger] RequestItalianRedWine request, ILogger log)
        {
            log.LogInformation($"{nameof(ProcessItalianRedWineOrderOrchestrator)} received message: {request}");
            await _mediator.Send(request);
        }

        [FunctionName(nameof(CheckInventory))]
        public async Task CheckInventory([ActivityTrigger] RequestInventoryCheck request, ILogger log)
        {
            log.LogInformation($"{nameof(ProcessItalianRedWineOrderOrchestrator)} received message: {request}");
            await _mediator.Send(request);
            
        }

    }
}