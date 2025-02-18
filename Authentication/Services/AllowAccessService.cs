using Authentication.Dtos.AllowAccess;
using Authentication.Models;
using Authentication.Repository.Interface;
using Authentication.Services.Interface;
using AutoMapper;

namespace Authentication.Services;

public class AllowAccessService : IAllowAccessService
{
    private readonly IRepository<AllowAccess> _repository;
    private readonly IMapper _mapper;

    public AllowAccessService(IRepository<AllowAccess> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<AllowAccessResponseDtos>> GetAllAsync()
    {
        var allowAccessEntities = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<AllowAccessResponseDtos>>(allowAccessEntities);
    }

    public async Task<AllowAccessResponseDtos> GetByIdAsync(int id)
    {
        var allowAccessEntity = await _repository.GetByIdAsync(id);
        if (allowAccessEntity == null)
        {
            throw new KeyNotFoundException("AllowAccess not found");
        }

        return _mapper.Map<AllowAccessResponseDtos>(allowAccessEntity);
    }

    public async Task<AllowAccessResponseDtos> CreateAsync(AllowAccessCreateDtos allowAccessCreateDto)
    {
        var allowAccessEntity = _mapper.Map<AllowAccess>(allowAccessCreateDto);
        await _repository.AddAsync(allowAccessEntity);
        return _mapper.Map<AllowAccessResponseDtos>(allowAccessEntity);
    }

    public async Task<AllowAccessResponseDtos> UpdateAsync(int id, AllowAccessUpdateDtos allowAccessUpdateDto)
    {
        var allowAccessEntity = await _repository.GetByIdAsync(id);
        if (allowAccessEntity == null)
        {
            throw new KeyNotFoundException("AllowAccess not found");
        }

        _mapper.Map(allowAccessUpdateDto, allowAccessEntity);
        await _repository.UpdateAsync(allowAccessEntity);
        return _mapper.Map<AllowAccessResponseDtos>(allowAccessEntity);
    }

    public async Task<string> DeleteAsync(int id)
    {
        var allowAccessEntity = await _repository.GetByIdAsync(id);
        if (allowAccessEntity == null)
        {
            throw new KeyNotFoundException("AllowAccess not found");
        }

        await _repository.DeleteAsync(id);
        return "AllowAccess deleted successfully";
    }
}