using API.App.Domain.Common;

namespace API.App.Domain.Interfaces;

public interface IFileService
{
    Task<OperationResult<string>> WriteToFile(string content);
    Task<OperationResult<List<string>>> WriteManyToFile(List<string> contentList);
}