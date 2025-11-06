using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Poe.Infraestructure.Data;

namespace Poe.Infraestructure.Repositories;

public abstract class RepositoryBase<TEntity>(PoeDbContext context) : IRepositoryBase<TEntity> where TEntity : class
{  
   
    private PoeDbContext _context = context;


    public async Task<TEntity?> GetByIdAsync(Guid id)
    {
        return await _context.Set<TEntity>().FindAsync(id);    
     
         
    } 

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        await _context.Set<TEntity>().ToListAsync();
        return await Task.FromResult<IEnumerable<TEntity>>(_context.Set<TEntity>().ToList());
    }

    public async Task CreateAsync(TEntity entity)
    {
        await  _context.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TEntity entity)
    {
         _context.Update(entity);
         await _context.SaveChangesAsync();
        
    }

    public async Task DeleteAsync(TEntity entity)
    {
        _context.Remove(entity);
        await _context.SaveChangesAsync();
    }
}

