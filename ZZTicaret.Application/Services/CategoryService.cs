using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZZTicaret.Application.DTO.Product;
using ZZTicaret.Application.Repositories;
using ZZTicaret.Domain;

namespace ZZTicaret.Application.Services
{
    public class CategoryService : ICategoryService
    {
        readonly ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<Category> GetCategoryByIdAsync(Guid categoryId)
        {
            return await _repository.GetByIdAsync(categoryId);
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return await _repository.GetAllAsync();
        }

        public async Task CreateCategory(Category category)
        {
           await _repository.AddAsync(category);
            await _repository.SaveAsync();

        }

         public async Task UpdateCategory(Category category)
        {
            _repository._dbSet.Entry(category).State = EntityState.Modified;
            await _repository.SaveAsync();
        }
        

        public async Task DeleteCategory(Guid categoryId)
        {
            var category = await _repository.GetByIdAsync(categoryId);
            if (category != null)
            {
                _repository.Delete(category);
                await _repository.SaveAsync();
            }


        }
    }
}
