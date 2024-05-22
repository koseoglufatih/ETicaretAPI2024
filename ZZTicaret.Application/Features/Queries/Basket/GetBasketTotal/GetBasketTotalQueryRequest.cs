using MediatR;

namespace ZZTicaret.Application.Features.Queries.Basket.GetBasketItems
{
    public class GetBasketTotalQueryRequest : IRequest<GetBasketTotalQueryResponse>              //GetBasketTotalQuery---Olarak değiştirilecek.
    {
    public Guid UserId {get;set;}
    }
}
