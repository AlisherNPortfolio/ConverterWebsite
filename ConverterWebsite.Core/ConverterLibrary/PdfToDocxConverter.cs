using ConverterWebsite.Core.ConverterContracts;

namespace ConverterWebsite.Core.ConverterLibrary;

public class PdfToDocxConverter : IFileConverter
{
    public Task<byte[]> ConvertAsync(byte[] bytes)
    {
        throw new NotImplementedException();
    }
}