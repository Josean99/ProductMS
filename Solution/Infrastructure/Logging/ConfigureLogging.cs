using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Logging
{
    public static class ConfigureLogging
    {
        public static ILoggingBuilder RegisterLogging(this ILoggingBuilder logging, ConfigurationManager config)
        {
            var logger = new LoggerConfiguration()
                //.WriteTo.File("C:\\Users\\Josean\\Desktop\\PatxiPersianasWriteAPI\\logs\\", rollingInterval: RollingInterval.Day, restrictedToMinimumLevel: )
                .ReadFrom.Configuration(config)
                .Enrich.FromLogContext()
                .CreateLogger();

            logging.ClearProviders();
            logging.AddSerilog(logger);

            return logging;
        }
    }
}
