namespace ZZTicaret.Application.Features.Commands.Basket.AddProductToBasket
{
    public class AddProductToBasketCommandResponse
    {
        public string BasketItemId { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
    }
}