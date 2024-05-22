using Microsoft.EntityFrameworkCore;
using ZZTicaret.Application.Features.Queries.Product.GetByCategoryId;
using ZZTicaret.Application.Repositories;
using ZZTicaret.Domain;

namespace ZZTicaret.Persistence.Repositories
{

    public class ProductRepository : Repository<Product>, IProductRepository
    {

        private readonly ZZTicaretContext _context;

        public ProductRepository(ZZTicaretContext context) : base(context)
        {
            _context = context;
        }

        public async Task<GetByCategoryIdQueryResponse> GetProductListByCategoryId(Guid categoryId)
        {

            var data = await _context.Products.Include(p => p.CategoryId).Where(p => p.CategoryId == categoryId).ToListAsync();
            return new GetByCategoryIdQueryResponse
            {
                ProductList = data
               
            };
        }
    }
}



            //// Eğer all true ise statusu hem true hem de false olanları getiriyor. Eğer all false ise hepsini getirme status 1 olanları getir demek o zaman true yazılıyor.

            //var data = await _context.Products.Include(p => p.Category).Where(p => p.CategoryId == categoryId && (all ? true : p.Status == true)).AsNoTracking().ToListAsync();
            //return new GetByCategoryIdQueryResponse()
            //{
            //    ProductList = data,
            //    TotalProductCount = data.Count()
            //};

    
   
    

