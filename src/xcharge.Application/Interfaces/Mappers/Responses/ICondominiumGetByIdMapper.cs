using xcharge.Application.DTOs.Condominium.Responses;
using xcharge.Domain.Entities;

namespace xcharge.Application.Interfaces.Mappers.Responses;

public interface ICondominiumGetByIdMapper
{
    CondominiumGetByIdDto Map(Domain.Entities.Condominium entity);
}
