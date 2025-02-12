using ConverterWebsite.Core.DTO.Requests;
using ConverterWebsite.Core.ServiceContracts;
using ConverterWebsite.Infastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ConverterWebsite.UI.Controllers;

public class FileConverterController : Controller
{
    private readonly ILogger<FileConverterController> _logger;
    private readonly IFileConverterService _fileConverterService;

    public FileConverterController(/*ILogger<FileConverterController> logger, */IFileConverterService _converterService)
    {
        //logger = _logger;
        _fileConverterService = _converterService;
    }

    [HttpGet]
    [Route("/")]
    public async Task<IActionResult> Index()
    {
        return View();
    }

    [Route("convert")]
    [HttpPost]
    public async Task<IActionResult> ConvertFile([FromForm] FileConversionRequest request)
    {
        if (request.File == null || request.File.Length == 0)
        {
            return BadRequest("No file uploaded");
        }
        
        var inputFileName = request.File.FileName;
        var outputFileName = Path.GetFileNameWithoutExtension(inputFileName) + "." + request.OutputFormat;
        
        var inputFormat = Path.GetExtension(inputFileName).TrimStart('.');
        var outputFormat = request.OutputFormat;

        if (inputFormat.Equals(outputFormat))
        {
            return BadRequest("Input and output formats are the same!");
        }
        
        var fileBytes = await ReadFileBytesAsync(request.File);
        await _fileConverterService.SaveFileAsync(inputFileName, fileBytes);

        var resultFileName =
            await _fileConverterService.ConvertFileAsync(inputFileName, outputFileName, inputFormat, outputFormat);

        var resultBytes = await _fileConverterService.GetFileAsync(resultFileName);
        var file = File(resultBytes, "application/octet-stream", resultFileName);
        return View(file);
    }

    private async Task<byte[]> ReadFileBytesAsync(IFormFile file)
    {
        using var memoryStream = new MemoryStream();
        await file.CopyToAsync(memoryStream);
        return memoryStream.ToArray();
    }
}