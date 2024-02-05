using MediatR;

namespace Application.Messages
{
    [Serializable]
    public class Wine: IRequest
    {
        public string? WineName { get; set; }
        public int WineQuantity { get; set; }
        public string? RequestId { get; set; }
        public int CustomerId { get; set; }
        public int OrderId { get; set; }

    }
}
