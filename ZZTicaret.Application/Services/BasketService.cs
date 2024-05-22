using ZZTicaret.Application.DTO.Basket;
using ZZTicaret.Application.Repositories;
using ZZTicaret.Domain;

namespace ZZTicaret.Application.Services
{
    public class BasketService : IBasketService
    {
        readonly IBasketRepository _basketRepository;
        readonly IProductRepository _productRepository;

        public BasketService(IBasketRepository basketRepository, IProductRepository productRepository)
        {
            _basketRepository = basketRepository;
            _productRepository = productRepository;
        }

        public async Task AddProductToBasket(Guid userId, Guid productId, int Quantity)
        {
            var basket = await _basketRepository.GetByIdAsync(userId);
            if (basket == null)
            {
                basket = new Basket { UserId = userId };
                await _basketRepository.AddAsync(basket);
            }
            var product = await _productRepository.GetByIdAsync(productId);
            if (product == null)
            {
                throw new ProductNotFoundException();
            }
            var basketItem = basket.BasketItems.FirstOrDefault(bi => bi.ProductId == productId);
            if (basketItem == null)
            {
                basketItem = new BasketItem { ProductId = productId, Quantity = Quantity };
                basket.BasketItems.Add(basketItem);
            }
            else
            {
                basketItem.Quantity += Quantity;
            }
            _basketRepository.Update(basket);
        }


        public async Task RemoveProductFromBasket(Guid userId, Guid productId)
        {
            var basket = await _basketRepository.GetByIdAsync(userId);
            if (basket != null)
            {
                var basketItem = basket.BasketItems.FirstOrDefault(item => item.ProductId == productId);
                if (basketItem != null)
                {
                    basket.BasketItems.Remove(basketItem);
                    _basketRepository.Update(basket);
                }
            }
        }

        public async Task ClearBasket(Guid userId)

        {
            var basket = await _basketRepository.GetByIdAsync(userId);
            if (basket != null)
            {
                basket.BasketItems.Clear();
                 _basketRepository.Update(basket);
            }
        }


        public async Task<decimal> GetBasketTotal(Guid UserId)
        {
            var basket = await _basketRepository.GetByIdAsync(UserId);
            if (basket != null)
            {
                return basket.BasketItems.Sum(bi => bi.Quantity * bi.Product.Price);
            }
            return 0;
        }

        public async Task<List<Create_BasketItem>> GetBasketItems(Guid userId)

        {
            var basket = await _basketRepository.GetByIdAsync(userId);
            if (basket != null)
            {
                return basket.BasketItems.Select(bi => new Create_BasketItem
                {
                    ProductId = bi.ProductId.ToString(),
                    Quantity = bi.Quantity,
                    Productname = bi.Product.Name,
                    UnitPrice = bi.Product.Price
                }).ToList();
            }
            return new List<Create_BasketItem>();
        }
    }
}








