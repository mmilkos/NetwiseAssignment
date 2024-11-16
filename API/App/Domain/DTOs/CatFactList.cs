namespace API.App.Domain;

public class CatFactList
{
    public int CurrentPage { get; set; }
    public List<CatFact> Data { get; set; }
    public string FirstPageUrl { get; set; }
    public int From { get; set; }
    public int LastPage { get; set; }
    public string LastPageUrl { get; set; }
    public List<object> Links { get; set; }
    public string NextPageUrl { get; set; }
    public string Path { get; set; }
    public int PerPage { get; set; }
    public string PrevPageUrl { get; set; }
    public int To { get; set; }
    public int Total { get; set; }
}