using System.Xml.Serialization;
using System.IO;

[XmlRoot("Configuration")]
public class Configuration
{
    [XmlElement("connectionString")]
    public string ConnectionString { get; set; }
    [XmlElement("query")]
    public string Query { get; set; }
    [XmlElement("resultPath")]
    public string ResultPath { get; set; } = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\result.txt";
}
public class ConfigLoader
{
    private string _configFile;
    public ConfigLoader(string configFile)
    {
        _configFile = configFile;
    }
    public Configuration LoadConfig()
    {
        CheckConfigExistOrCreate(_configFile);
        XmlSerializer serializer = new XmlSerializer(typeof(Configuration));
        using (var reader = new StreamReader(_configFile))
        {
            return (Configuration)serializer.Deserialize(reader);
        }
    }
    private void CheckConfigExistOrCreate(string config)
    {
        if (File.Exists("config.xml"))
        {
            Console.WriteLine("Config file exist.");
        }
        else
        {
            // TODO: Add UI to create config file and save
            Console.WriteLine("Config file not exist.");
        }
    }
}