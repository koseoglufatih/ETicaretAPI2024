using MediatR;

namespace ZZTicaret.Application.Features.Commands.Product.Create
{
    public class CreateProductCommandRequest : IRequest<CreateProductCommandResponse>
    {
        public Guid CategoryID { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public int Price { get; set; }

    }
}