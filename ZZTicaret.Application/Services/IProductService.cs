using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZZTicaret.Application.DTO.Product;

namespace ZZTicaret.Application.Services
{
    public interface IProductService
    {
        Task CreateProductAsync(ProductDTO productDTO);
        Task GetAllProductAsync();
        Task GetProductByIdAsync(Guid id);
        Task RemoveProduct(Guid id);
        

        

    }
}
