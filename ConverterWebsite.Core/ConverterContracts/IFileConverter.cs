namespace ConverterWebsite.Core.ConverterContracts;

public interface IFileConverter
{
    Task<byte[]> ConvertAsync(byte[] bytes);
}