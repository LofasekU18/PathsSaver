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

        stopwatch.Start();
        _view.PrintMessage("Loading data from db");
        var _listOfPaths = await _dbReader.DbReadAsync();
        stopwatch.Stop();
        _view.PrintMessage("Loaded: " + _listOfPaths.Count.ToString() + " files in " + stopwatch.Elapsed.ToString());
        _view.WaitForUser();
        await _fileWriter.WriteDataAsync(_listOfPaths);
        _view.PrintMessage($"Paths saved to {_configuration.ResultPath}");
        _view.WaitForUser();
    }
}