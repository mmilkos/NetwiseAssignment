using API.App.Domain;
using API.App.Domain.Common;
using API.App.Domain.Interfaces;

namespace API.App.Application.Services;

public class FactService : IFactService
{
    private readonly IRepository _repository;

    public FactService(IRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<OperationResult<CatFact>> GetRandomCatFactAsync()
    {
        var result = new OperationResult<CatFact>();

        try
        {
            result.Data = await _repository.GetRandomCatFactAsync();
        }
        catch (Exception e)
        {
            result.AddError(e.Message);
        }

        return result;
    }

    public async Task<OperationResult<List<CatFact>>> GetCatFactListAsync(int page)
    {
        var result = new OperationResult<List<CatFact>>();

        try
        {
            var catFactList = await _repository.GetCatFactListAsync(page);
            result.Data = catFactList.Data;
        }
        catch (Exception e)
        {
            result.AddError(e.Message);
        }

        return result;
    }
}