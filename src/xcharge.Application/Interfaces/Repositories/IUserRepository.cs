using xcharge.Application.DTOs.Condominium.Responses;
using xcharge.Domain.Entities;

namespace xcharge.Application.Interfaces.Repositories;

public interface IUserRepository
{
    Task<User> GetById(Guid id);
    Task<Guid> Create(User entity);
    Task<IEnumerable<UserSearchDto>> GetAllPaged(string name);
}
