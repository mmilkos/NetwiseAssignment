using API.App.Domain;
using API.App.Domain.Common;
using API.App.Domain.Interfaces;
using API.App.Extensions;
using Microsoft.Extensions.Options;

namespace API.App.Infrastructure.Repositories;

public class Repository : IRepository
{
    private readonly string _apiUrl;

    public Repository(IOptions<Settings> settings)
    {
        _apiUrl = settings.Value.ApiUrl;
    }

    public async Task<CatFact> GetRandomCatFactAsync()
    {
        var result = await _apiUrl.GetAsync();
        
        return result.Deserialize<CatFact>() ;
    }

    public async Task<CatFactList> GetCatFactListAsync(int page)
    {
        var url = $"{_apiUrl}s?page={page}";
        
        var result = await url.GetAsync();

        return result.Deserialize<CatFactList>();
    }
}