using System.IO;
using System.Text;
class FileWriter
{
    private string _path;
    private List<string> _listOfPaths;
    public FileWriter(string path, List<string> listOfPaths)
    {
        _path = path ?? Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\result.txt";
        _listOfPaths = listOfPaths;
    }
    public async Task WriteDataAsync()
    {
        using (var writer = new StreamWriter(_path, false, Encoding.UTF8))
        {
            foreach (var record in _listOfPaths)
            {
                await writer.WriteLineAsync(record);
            }
        }
    }
}
