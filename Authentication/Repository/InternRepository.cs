using Authentication.Data;
using Authentication.Models;
using Authentication.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Repository;

public class InternRepository : IRepository<Intern>
{
    private readonly ApplicationDbContext _context;

    public InternRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Intern>> GetAllAsync()
    {
        return await _context.Interns.ToListAsync();
    }

    public async Task<Intern?> GetByIdAsync(int id)
    {
        return await _context.Interns.FindAsync(id);
    }

    public async Task AddAsync(Intern entity)
    {
        await _context.Interns.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Intern entity)
    {
        _context.Interns.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _context.Interns.FindAsync(id);
        if (entity != null)
        {
            _context.Interns.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}