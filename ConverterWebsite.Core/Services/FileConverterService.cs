using ConverterWebsite.Core.ConverterLibrary;
using ConverterWebsite.Core.ServiceContracts;
using ConverterWebsite.Infastructure.Repositories.Contracts;

namespace ConverterWebsite.Core.Services;

public class FileConverterService : IFileConverterService
{
    private readonly IFileRepository _fileRepository;

    public FileConverterService(IFileRepository fileRepository)
    {
        _fileRepository = fileRepository;
    }
    
    public async Task<string> ConvertFileAsync(string inputFileName, string outputFileName, string inputFormat, string outputFormat)
    {
        var fileBytes = await _fileRepository.GetFileAsync(inputFileName);
        var converter = FileConverterFactory.CreateConverter(inputFormat, outputFormat);
        var convertedBytes = await converter.ConvertAsync(fileBytes);

        await _fileRepository.SaveFileAsync(outputFileName, convertedBytes);
        
        return outputFileName;
    }

    public async Task SaveFileAsync(string inputFileName, byte[] fileBytes)
    {
        await _fileRepository.SaveFileAsync(inputFileName, fileBytes);
    }

    public async Task<byte[]> GetFileAsync(string resultFileName)
    {
        return await _fileRepository.GetFileAsync(resultFileName);
    }
}