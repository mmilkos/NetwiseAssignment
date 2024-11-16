using API.App.Application.Services;
using API.App.Domain.Common;
using API.App.Domain.Interfaces;
using API.App.Infrastructure.Repositories;

namespace API.App.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddExtensions(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IRepository, Repository>();
        services.AddScoped<IFactService, FactService>();
        services.AddScoped<IFileService, FileService>();
        services.Configure<Settings>(configuration.GetSection("Settings"));
    }
}