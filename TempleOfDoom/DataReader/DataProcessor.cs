using DataReader.DTO;
using DataReader.Interface;

namespace DataReader;

public class DataProcessor
{
    private IFileReader? _fileReaderStrategy;

    public DataProcessor(IFileReader? fileReaderStrategy)
    {
        this._fileReaderStrategy = fileReaderStrategy;
    }
    public GameObject ProcessData(string file)
    {
        return _fileReaderStrategy.ReadData(file);
    }
}