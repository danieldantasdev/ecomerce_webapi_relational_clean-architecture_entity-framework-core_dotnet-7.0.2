using Microsoft.EntityFrameworkCore;
using VirtualStore.Core.Entities;
using VirtualStore.Core.Interfaces.Repositories;
using VirtualStore.Infrastructure.Persisntences.Context;

namespace VirtualStore.Infrastructure.Implementations.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly VirtualStoreDbContext _virtualStoreDbContext;

    public CategoryRepository(VirtualStoreDbContext virtualStoreDbContext)
    {
        _virtualStoreDbContext = virtualStoreDbContext;
    }


    public async Task<List<Category>> GetAll()
    {
        return _virtualStoreDbContext.Categories.ToList();
    }

    public async Task<Category> GetById(int id)
    {
        return await _virtualStoreDbContext.Categories.SingleOrDefaultAsync(c => c.Id == id);
    }

    public async Task Add(Category entity)
    {
        await _virtualStoreDbContext.Categories.AddAsync(entity);
        await _virtualStoreDbContext.SaveChangesAsync();
    }

    public async Task Update(Category entity)
    {
        throw new NotImplementedException();
    }

    public async Task Delete(Category entity)
    {
        throw new NotImplementedException();
    }
}