using DataReader.Interface;
using DataReader.Readers;

namespace DataReader.Factories;

public class FileReaderFactory
{
    public IFileReader CreateFileReader(string filePath)
    {
        string extension = Path.GetExtension(filePath)?.ToLower();
        
        if (!string.IsNullOrEmpty(extension) && extension.Length > 1)
        {
            extension = extension.Substring(1); 
        }
        
        return extension switch
        {
            "json"  => new JsonFileReader(),
            _ => throw new ArgumentException($"Unknown file type: {extension}")
        };
    }
}