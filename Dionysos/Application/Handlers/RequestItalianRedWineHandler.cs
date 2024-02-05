using Application.Messages;
using AutoMapper;
using Infrastructure.DataBase;
using Infrastructure.DataBase.Tables;
using MediatR;

namespace Application.Handlers
{
    public class RequestItalianRedWineHandler : IRequestHandler<RequestItalianRedWine>
    {
        private readonly DataBaseContext _context;
        private readonly IMapper _mapper;


        public RequestItalianRedWineHandler(DataBaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task Handle(RequestItalianRedWine request, CancellationToken cancellationToken)
        {

            // Mapp message to Order
            var orderMapped = _mapper.Map<Order>(request);

            // Add order to the database
            await _context.AddAsync(orderMapped, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            // check if customer already exists
            var isExistingCustomer = _context.Customers.Single(c => c.CustomerId == request.CustomerId);

        }
    }
}
