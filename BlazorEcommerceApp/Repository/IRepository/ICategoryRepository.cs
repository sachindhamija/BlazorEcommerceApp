using System;

using BlazorEcommerceApp.Data;

namespace BlazorEcommerceApp.Repository.IRepository;

public interface ICategoryRepository
{
    public Task<Category> CreateAsync(Category category);
    public Task<Category> UpdateAsync(Category category);
    public Task<bool> DeleteAsync(int categoryId);
    public Task<Category> GetAsync(int id);

    public Task<IEnumerable<Category>> GetAllAsync();
}
