using Application.Logging.Serilog.ConfigurationModels;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;
using static Serilog.Sinks.MSSqlServer.ColumnOptions;

namespace Application.Logging.Serilog.Logger;

public class DatabaseLogger : LoggerServiceBase
{
    private IConfiguration _configuration;

    public DatabaseLogger(IConfiguration configuration)
    {
        _configuration = configuration;

        var dbLogConfig = configuration.GetSection("SeriLogConfigurations:DatabaseLogConfiguration")
                              .Get<DatabaseLogConfiguration>() ??
                          throw new Exception("Database log configuration is missing.");

        Logger = new LoggerConfiguration()
            .WriteTo.MSSqlServer(
                connectionString: dbLogConfig.ConnectionString,
                tableName: dbLogConfig.TableName,
                autoCreateSqlTable: true,
                columnOptions: new ColumnOptions(),
                restrictedToMinimumLevel: LogEventLevel.Information
            )
            .CreateLogger();
    }
}
