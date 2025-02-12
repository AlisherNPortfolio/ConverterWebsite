using ConverterWebsite.Infastructure.Repositories.Contracts;
using Microsoft.Extensions.Configuration;

namespace ConverterWebsite.Infastructure.Repositories;

public class FileRepository : IFileRepository
{
    private readonly string _storagePath;

    public FileRepository(IConfiguration configuration)
    {
        _storagePath = configuration["StoragePath"] ?? "TempStorage";
        if (!Directory.Exists(_storagePath))
        {
            Directory.CreateDirectory(_storagePath);
        }
    }
    
    public async Task SaveFileAsync(string fileName, byte[] bytes)
    {
        var filePath = Path.Combine(_storagePath, fileName);
        await File.WriteAllBytesAsync(filePath, bytes);
    }

    public async Task<byte[]> GetFileAsync(string fileName)
    {
        var filePath = Path.Combine(_storagePath, fileName);
        return await File.ReadAllBytesAsync(filePath);
    }
}