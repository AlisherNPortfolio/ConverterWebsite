using Microsoft.AspNetCore.Http;

namespace ConverterWebsite.Core.DTO.Requests;

public class FileConversionRequest
{
    public IFormFile File { get; set; }
    public string OutputFormat { get; set; }
}