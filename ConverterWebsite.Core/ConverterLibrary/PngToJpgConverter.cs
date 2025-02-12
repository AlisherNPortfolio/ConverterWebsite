using ConverterWebsite.Core.ConverterContracts;

namespace ConverterWebsite.Core.ConverterLibrary;

public class PngToJpgConverter : IFileConverter
{
    public Task<byte[]> ConvertAsync(byte[] bytes)
    {
        throw new NotImplementedException();
    }
}