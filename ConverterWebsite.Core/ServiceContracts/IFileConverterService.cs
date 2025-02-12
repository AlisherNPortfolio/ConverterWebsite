namespace ConverterWebsite.Core.ServiceContracts;

public interface IFileConverterService
{
    Task<string> ConvertFileAsync(string inputFileName, string outputFileName, string inputFormat, string outputFormat);
    Task SaveFileAsync(string inputFileName, byte[] fileBytes);

    Task<byte[]> GetFileAsync(string resultFileName);
}