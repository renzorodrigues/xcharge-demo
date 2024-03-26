using Microsoft.EntityFrameworkCore;
using xcharge.Application.DTOs.Condominium.Responses;
using xcharge.Application.Interfaces.Repositories;
using xcharge.Domain.Entities;
using xcharge.Infrastructure.Data.DataContext;

namespace xcharge.Infrastructure.Data.Repositories;

public class UserRepository(ApplicationDbContext dbContext) : IUserRepository
{
    private readonly ApplicationDbContext _dbContext = dbContext;

    public async Task<Guid> Create(User entity)
    {
        this._dbContext.Add(entity);
        await this._dbContext.SaveChangesAsync();
        return entity.Id;
    }

    public async Task<IEnumerable<UserSearchDto>> GetAllPaged(string name)
    {
        var result = await this
            ._dbContext.User.Where(x => x.FullName!.ToLower()!.Contains(name.ToLower()))
            .Select(x => new UserSearchDto
            {
                FullName = x.FullName,
                Id = x.Id,
                CPF = x.Identification!.Cpf
            })
            .ToListAsync();

        return result;
    }

    public async Task<User> GetById(Guid id)
    {
        var result = await this._dbContext.User.FirstOrDefaultAsync(u => u.Id == id);

        return result!;
    }
}
