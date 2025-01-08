namespace Application.Logging.Serilog.ConfigurationModels;

public class DatabaseLogConfiguration
{
    public string ConnectionString { get; set; }
    public string TableName { get; set; }
}