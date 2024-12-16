using System.Data.OleDb;
public class DbReader
{
    private string _connectionString;
    private string _query;

    public DbReader(Configuration configuration)
    {
        _connectionString = configuration.ConnectionString;
        _query = configuration.Query;
    }
    public async Task<List<string>> DbReadAsync()
    {
        List<string> ListOfPaths = new();
        using (OleDbConnection connection = new OleDbConnection(_connectionString))
        {
            OleDbCommand command = new OleDbCommand(_query, connection);
            await connection.OpenAsync();
            OleDbDataReader reader = (OleDbDataReader)await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                ListOfPaths.Add(reader.GetValue(0)?.ToString() ?? "Null");
            }

            await reader.CloseAsync();
        }
        return ListOfPaths;
    }

}
