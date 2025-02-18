﻿using Microsoft.Extensions.Configuration;

namespace Persistence;

internal static class Configuration
{
    public static string? ConnectionString
    {
        get
        {
            ConfigurationManager configurationManager = new();
            configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/WebAPI"));
            configurationManager.AddJsonFile("appsettings.json");

            return configurationManager.GetConnectionString("SqlServer");
        }
    }
}