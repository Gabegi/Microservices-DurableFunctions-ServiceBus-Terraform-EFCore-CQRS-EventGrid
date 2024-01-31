using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System;
using MediatR;
using DTO;

namespace DionysosRouter
{
    public class Starter
    {
        private readonly IMediator _mediator;

        public Starter(IMediator mediator)
        {
            _mediator = mediator;
        }

        [FunctionName(nameof(StartRequestItalianRedWine))]
        public async Task<IActionResult> StartRequestItalianRedWine(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] RequestItalianRedWineDto request,
            ILogger log)
        {
            log.LogInformation("Starter function processed a request");

            string responseMessage = string.IsNullOrEmpty(request.WineName)
                ? "This HTTP triggered function executed successfully but the wine name is empty. Please select an item and quantity"
                : $"Thank you for ordering {request.WineQuantity} {request.WineName}. We are processing your request. Your wine has a tanic level of {request.TanicLevelOutOfTen}, we recommend strong meat for tanic levels higher than 7.5";

            request.RequestId = Guid.NewGuid().ToString();

            await _mediator.Send(request);

            return new OkObjectResult(responseMessage);
        }

        
    }
}
