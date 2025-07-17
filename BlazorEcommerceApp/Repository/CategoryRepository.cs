using System;
using BlazorEcommerceApp.Data;
using BlazorEcommerceApp.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BlazorEcommerceApp.Repository;

public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _db;
    public CategoryRepository(ApplicationDbContext db)
    {
        _db = db;
    }
    public async Task<Category> CreateAsync(Category category)
    {
        await _db.Category.AddAsync(category);
        await _db.SaveChangesAsync();
        return category;

    }

    public async Task<bool> DeleteAsync(int categoryId)
    {
        var categoryToDelete = await _db.Category.FirstOrDefaultAsync(x => x.Id == categoryId);
        if (categoryToDelete != null)
        {
            _db.Category.Remove(categoryToDelete);
            return await _db.SaveChangesAsync() > 0;
        }
        return false;
    }

    public async Task<Category> GetAsync(int id)
    {
        var category = await _db.Category.FirstOrDefaultAsync(x => x.Id == id);
        if (category != null)
        {
            return category;
        }
        return new Category();
    }

    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        return await _db.Category.ToListAsync();
    }

    public async Task<Category> UpdateAsync(Category category)
    {
        var categoryFromDatabase = await _db.Category.FirstOrDefaultAsync(x => x.Id == category.Id);
        if (categoryFromDatabase is not null)
        {
            categoryFromDatabase.Name = category.Name;
            _db.Category.Update(category);
            await _db.SaveChangesAsync();
            return categoryFromDatabase;
        }
        return category;
    }
}
