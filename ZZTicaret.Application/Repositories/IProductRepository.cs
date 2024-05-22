using ZZTicaret.Application.Features.Queries.Product.GetByCategoryId;
using ZZTicaret.Domain;

namespace ZZTicaret.Application.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<GetByCategoryIdQueryResponse> GetProductListByCategoryId(Guid categoryId);
    }
}
