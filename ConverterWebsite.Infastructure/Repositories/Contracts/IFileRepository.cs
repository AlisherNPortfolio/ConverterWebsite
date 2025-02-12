namespace ConverterWebsite.Infastructure.Repositories.Contracts;

public interface IFileRepository
{
    Task SaveFileAsync(string fileName, byte[] bytes);
    Task<byte[]> GetFileAsync(string fileName);
}