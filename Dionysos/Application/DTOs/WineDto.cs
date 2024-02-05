using MediatR;

namespace DTO
{
    public class WineDtoRequest: IRequest
    {
        public string? WineName { get; set; }
        public int WineQuantity { get; set; }
        public string? RequestId { get; set; }
        public int CustomerId { get; set; }
        public int OrderId { get; set; }

    }
}
