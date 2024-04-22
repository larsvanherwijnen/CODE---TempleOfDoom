using DataReader.DTO;

namespace DataReader.Interface;

public interface IFileReader
{
    GameObject ReadData(string file);
}
