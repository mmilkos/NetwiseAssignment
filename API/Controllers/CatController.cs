using API.App.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class CatController : ControllerBase
{
    private readonly IFactService _factService;
    private readonly IFileService _fileService;
    
    public CatController(IFactService factService, IFileService fileService)
    {
        _factService = factService;
        _fileService = fileService;
    }
}