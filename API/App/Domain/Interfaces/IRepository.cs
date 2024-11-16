namespace API.App.Domain.Interfaces;

public interface IRepository
{
    Task<CatFact> GetRandomCatFactAsync();
    Task<CatFactList> GetCatFactListAsync(int page);
}