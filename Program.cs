class Program
{
    public static async Task Main(string[] args)
    {

        ConfigLoader _configLoader = new("config.xml");
        Configuration _configuration = _configLoader.LoadConfig();
        DbReader _dbReader = new DbReader(_configuration);
        FileWriter _fileWriter = new FileWriter(_configuration.ResultPath);
        var _listOfPaths = await _dbReader.DbReadAsync();
        await _fileWriter.WriteDataAsync(_listOfPaths);

        Console.WriteLine(_configuration.ConnectionString);
        Console.WriteLine(_configuration.Query);
        Console.WriteLine(_configuration.ResultPath);

    }
}