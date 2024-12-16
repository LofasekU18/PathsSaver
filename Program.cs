using System.Diagnostics;

class Program
{
    public static async Task Main(string[] args)
    {
        View _view = new View();
        ConfigLoader _configLoader = new("config.xml");
        Configuration _configuration = _configLoader.LoadConfig();
        DbReader _dbReader = new DbReader(_configuration);
        FileWriter _fileWriter = new FileWriter(_configuration.ResultPath);
        Stopwatch stopwatch = new();

        _view.PrintMessage("Loading data from db");
        var _listOfPaths = await _dbReader.DbReadAsync();
        _view.PrintMessage("Loaded: " + _listOfPaths.Count.ToString() + " files");
        _view.WaitForUser();
        await _fileWriter.WriteDataAsync(_listOfPaths);
        _view.PrintMessage($"Paths saved to {_configuration.ResultPath}");
        Console.WriteLine(_configuration.ConnectionString);
        Console.WriteLine(_configuration.Query);
        Console.WriteLine(_configuration.ResultPath);

    }
}