using System.Text.Json;
using DataReader.DTO;
using DataReader.Interface;


namespace DataReader.Readers;

public class JsonFileReader : IFileReader
{
    public GameObject ReadData(string file)
    {
        string json = File.ReadAllText(file);
        GameObject root = JsonSerializer.Deserialize<GameObject>(json);

        return root;
    }
    
}


