using API.App.Domain.Common;
using API.App.Domain.Interfaces;
using Microsoft.Extensions.Options;

namespace API.App.Infrastructure.Repositories;

public class Repository : IRepository
{
    private readonly string _apiUrl;

    public Repository(IOptions<Settings> settings)
    {
        _apiUrl = settings.Value.ApiUrl;
    }
}