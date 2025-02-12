using ConverterWebsite.Core.ConverterContracts;

namespace ConverterWebsite.Core.ConverterLibrary;

public static class FileConverterFactory
{
    public static IFileConverter CreateConverter(string inputFormat, string outputFormat)
    {
        if (inputFormat.Equals("pdf", StringComparison.OrdinalIgnoreCase) &&
            outputFormat.Equals("pdf", StringComparison.OrdinalIgnoreCase))
        {
            return new PdfToDocxConverter();
        } else if (inputFormat.Equals("png", StringComparison.OrdinalIgnoreCase) &&
                   outputFormat.Equals("jpg", StringComparison.OrdinalIgnoreCase))
        {
            return new PngToJpgConverter();
        }
        
        throw new NotSupportedException($"Conversion from {inputFormat} to {outputFormat} is not supported.");
    }
}