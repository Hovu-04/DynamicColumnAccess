using Authentication.Data;
using Authentication.Dtos;
using Authentication.Dtos.Intern;
using Authentication.Models;
using Authentication.Repository.Interface;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Services.Interface;

public class InternService : IInternService
{
    private readonly IRepository<Intern> _repository;
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _context;
    private readonly IRoleService _roleService;
    public InternService(IRepository<Intern> repository, IMapper mapper, ApplicationDbContext context, IRoleService roleService)
    {
        _repository = repository;
        _mapper = mapper;
        _context = context;
        _roleService = roleService;
    }


    public async Task<IEnumerable<InternResponseDtos>> GetAllAsync()
    {
        var interns = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<InternResponseDtos>>(interns);
    }

    public async Task<InternResponseDtos> GetByIdAsync(int id)
    {
        var intern = await _repository.GetByIdAsync(id);
        if (intern == null)
        {
            throw new KeyNotFoundException("Intern not found");
        }

        return _mapper.Map<InternResponseDtos>(intern);
    }

    public async Task<InternResponseDtos> CreateAsync(InternCreateDtos internCreateDtos)
    {
        var intern = _mapper.Map<Intern>(internCreateDtos);
    
        // Chuyển đổi DateOfBirth sang UTC nếu có giá trị
        if (intern.DateOfBirth.HasValue)
        {
            intern.DateOfBirth = DateTime.SpecifyKind(intern.DateOfBirth.Value, DateTimeKind.Utc);
        }
    
        await _repository.AddAsync(intern);
        return _mapper.Map<InternResponseDtos>(intern);
    }


    public async Task<InternResponseDtos> UpdateAsync(int id, InternUpdateDtos internUpdateDtos)
    {
        var intern = await _repository.GetByIdAsync(id);
        if (intern == null)
        {
            throw new KeyNotFoundException("Intern not found");
        }

        _mapper.Map(internUpdateDtos, intern);
        await _repository.UpdateAsync(intern);
        return _mapper.Map<InternResponseDtos>(intern);
    }

    public async Task<string> DeleteAsync(int id)
    {
        var intern = await _repository.GetByIdAsync(id);
        if (intern == null)
        {
            throw new KeyNotFoundException("Intern not found");
        }

        await _repository.DeleteAsync(id);
        return "Intern deleted successfully";
    }
    
    public async Task<List<Dictionary<string, object>>> GetInternInfoByRoleAsync(int roleId)
    {
        var allowedColumns = await _context.AllowAccesses
            .Where(a => a.RoleId == roleId && a.TableName == "Intern")
            .Select(a => a.AccessProperties)
            .ToListAsync();

        var allowedColumnsList = allowedColumns
            .SelectMany(ac => ac.Split(","))
            .Distinct()
            .ToList();

        var query = _context.Interns.AsQueryable();
        var internResponseList = new List<Dictionary<string, object>>();

        foreach (var intern in await query.ToListAsync())
        {
            var validProperties = new Dictionary<string, object>();

            var internProperties = typeof(Intern).GetProperties();

            foreach (var property in internProperties)
            {
                if (allowedColumnsList.Contains(property.Name))
                {
                    var value = property.GetValue(intern);

                    if (value != null && !(value is string str && string.IsNullOrEmpty(str)))
                    {
                        validProperties[property.Name] = value;
                    }
                }
            }

            if (validProperties.Any())
            {
                internResponseList.Add(validProperties);
            }
        }

        return internResponseList;
    }
}