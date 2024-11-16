namespace API.App.Domain.Common;

public class OperationResult<T>
{
    public T Data { get; set; }
    public List<string> Errors { get; } = [];
    public bool Success { get; private set; } = true;

    public void AddError(string error)
    {
        Errors.Add(error);
        Success = false;
    }
}