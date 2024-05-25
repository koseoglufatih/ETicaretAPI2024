using ZZTicaret.Application.DTO.Basket;

namespace ZZTicaret.Application.Features.Queries.Basket.BetBasketByUserId
{
    public class GetBasketByUserIdCommandResponse
    {
        public Guid BasketId { get; set; }
        public ICollection<BasketItemDTO> BasketItems { get; set; }
        public decimal TotalAmount { get; set; }

        public string ErrorMessage { get; set; }
    }
}