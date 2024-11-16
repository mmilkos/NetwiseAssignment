using System.ComponentModel.DataAnnotations;
using API.App.Domain;
using API.App.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Controller]
[Route("api/catFacts")]
public class CatFactsController : ControllerBase
{
    private readonly IFactService _factService;
    private readonly IFileService _fileService;
    
    public CatFactsController(IFactService factService, IFileService fileService)
    {
        _factService = factService;
        _fileService = fileService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetCatFactsList([FromQuery] [Range(1, int.MaxValue)] int page = 1)
    {
        var factResult = await _factService.GetCatFactListAsync(page);

        if (factResult.Success == false) return StatusCode(500, factResult.Errors);

        var catFacts = factResult.Data.Select(data => data.Fact).ToList();
        
        var fileResult = await _fileService.WriteManyToFile(catFacts);

        if (fileResult.Success == false) return StatusCode(500, fileResult.Errors);
        
        return Ok();
    }

    [HttpGet("random")]
    public async Task<IActionResult> GetRandomCatFact()
    {
        var factResult = await _factService.GetRandomCatFactAsync();

        if (factResult.Success == false) return StatusCode(500, factResult.Errors);

        var fileResult = await _fileService.WriteToFile(factResult.Data.Fact);
        
        if (fileResult.Success == false) return StatusCode(500, fileResult.Errors);
        
        return Ok();
    }
}