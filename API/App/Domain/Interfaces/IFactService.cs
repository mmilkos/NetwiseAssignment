using API.App.Domain.Common;

namespace API.App.Domain.Interfaces;

public interface IFactService
{
    Task<OperationResult<CatFact>> GetRandomCatFactAsync();
    Task<OperationResult<List<CatFact>>> GetCatFactListAsync(int page);
}