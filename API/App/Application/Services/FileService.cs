using System.Text;
using API.App.Domain.Common;
using API.App.Domain.Interfaces;
using Microsoft.Extensions.Options;

namespace API.App.Application.Services;

public class FileService : IFileService
{
    private readonly string _filePath;

    public FileService(IOptions<Settings> settings)
    {
        
        var projectDirectory = Directory.GetCurrentDirectory();
        _filePath = Path.Combine(projectDirectory, settings.Value.FolderName, settings.Value.FileName);
    }
    
    public async Task<OperationResult<string>> WriteToFile(string content)
    {
        var result = new OperationResult<string>();
        
        try
        { 
            await File.AppendAllTextAsync(_filePath,content + "\n");
            result.Data = content;
        }
        catch (Exception e)
        {
            result.AddError(e.Message);
        }

        return result;
    }

    public async Task<OperationResult<List<string>>> WriteManyToFile(List<string> contentList)
    {
        var result = new OperationResult<List<string>>();
        
        try
        {
            var sb = new StringBuilder();
            foreach (var content in contentList) sb.AppendLine(content);
            
            await File.AppendAllTextAsync(_filePath, sb.ToString());
            
            result.Data = contentList;
        }
        catch (Exception e)
        {
            result.AddError(e.Message);
        }

        return result;
    }
}