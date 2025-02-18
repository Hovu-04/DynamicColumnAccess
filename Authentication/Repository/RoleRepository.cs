using Authentication.Data;
using Authentication.Models;
using Authentication.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Repository;

public class RoleRepository : IRepository<Role>
{
    private readonly ApplicationDbContext _context;

    public RoleRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Role>> GetAllAsync()
    {
        return await _context.Roles.ToListAsync();
    }

    public async Task<Role?> GetByIdAsync(int id)
    {
        return await _context.Roles.FindAsync(id);
    }

    public async Task AddAsync(Role entity)
    {
        await _context.Roles.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Role entity)
    {
        _context.Roles.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _context.Roles.FindAsync(id);
        if (entity != null)
        {
            _context.Roles.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}