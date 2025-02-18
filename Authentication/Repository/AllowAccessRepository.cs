using Authentication.Data;
using Authentication.Models;
using Authentication.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Repository;

public class AllowAccessRepository : IRepository<AllowAccess>
{
    private readonly ApplicationDbContext _context;

    public AllowAccessRepository(ApplicationDbContext context)
    {
        _context = context;
    }


    public async Task<IEnumerable<AllowAccess>> GetAllAsync()
    {
        return await _context.AllowAccesses.ToListAsync();
    }

    public async Task<AllowAccess?> GetByIdAsync(int id)
    {
        return await _context.AllowAccesses.FindAsync(id);
    }

    public async Task AddAsync(AllowAccess entity)
    {
        await _context.AllowAccesses.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(AllowAccess entity)
    {
        _context.AllowAccesses.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _context.AllowAccesses.FindAsync(id);
        if (entity != null)
        {
            _context.AllowAccesses.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}