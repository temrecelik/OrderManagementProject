using Application.Logging.Serilog.ConfigurationModels;
using Application.Logging.Serilog.Layouts;
using Application.Logging.Serilog.Messages;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace Application.Logging.Serilog.Logger;

public class FileLogger : LoggerServiceBase
{
    private IConfiguration _configuration;

    public FileLogger(IConfiguration configuration)
    {
        _configuration = configuration;


        FileLogConfiguration logConfig = configuration.GetSection("SeriLogConfigurations:FileLogConfiguration")
                                                      .Get<FileLogConfiguration>() ??
                                         throw new Exception(SerilogMessages.NullOptionsMessage);

        string logFilePath = $"{logConfig.FolderPath}log.json";

        Logger = new LoggerConfiguration()
            .WriteTo.File(
                new JsonLayout(),
                logFilePath,
                rollingInterval: RollingInterval.Day,
                retainedFileCountLimit: null,
                fileSizeLimitBytes: 5000000)
            .CreateLogger(); ;
    }
}