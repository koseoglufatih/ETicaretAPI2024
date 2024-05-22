using ZZTicaret.Application.DTO.Product;
using ZZTicaret.Application.Repositories;

namespace ZZTicaret.Application.Services
{
    public class ProductService : IProductService
    {
        readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateProductAsync(ProductDTO productDTO)
        {
            await _repository.AddAsync(new()
            {
                Id = Guid.NewGuid(),
                Name = productDTO.Name,
                Price = productDTO.Price
                
            });
            await _repository.SaveAsync();
        }

  

        public async Task GetAllProductAsync()
        {
           await _repository.GetAllAsync();
           
        }

        public async Task GetProductByIdAsync(Guid id)
        {
           await _repository.GetByIdAsync(id);
        }

        public async Task RemoveProduct(Guid id)
        {
            await _repository.Delete(id);
        }
    }
}
