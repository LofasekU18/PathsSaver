using System.IO;
using System.Text;
public class FileWriter
{
    // private const int MaxRowsPerFile = 60000;
    // private int _fileIndex = 0;
    // private int _recordCounter = 0;
    private string _path;
    public FileWriter(string path)
    {
        _path = path ?? Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\result.txt";
    }
    public async Task WriteDataAsync(List<string> listOfPaths)
    {
        using (var writer = new StreamWriter(_path, false, Encoding.UTF8))
        {
            foreach (var record in listOfPaths)
            {
                await writer.WriteLineAsync(record);
            }
        }
    }
}
