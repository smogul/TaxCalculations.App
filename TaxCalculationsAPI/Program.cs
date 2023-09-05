using NLog;
using NLog.Web;
using TaxCalculationsAPI.Models;

namespace TaxCalculationsAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
            var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
            logger.Debug("init main");

            try
            {
                var builder = WebApplication.CreateBuilder(args);

                // Add services to the container.

                builder.Services.AddControllers();
                // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
                builder.Services.AddEndpointsApiExplorer();
                builder.Services.AddSwaggerGen();
                // Add services to the container.
                builder.Services.AddSqlServer<Db_TaxCalculationContext>(builder.Configuration.GetConnectionString("DefaultConnection"));
                //configure logging
                //builder.Services.AddLogging(loggingBuilder =>
                //{
                //    loggingBuilder.ClearProviders();
                //    loggingBuilder.AddNLog();
                //});

                // NLog: Setup NLog for Dependency injection
                builder.Logging.ClearProviders();
                builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
                builder.Host.UseNLog();

                var app = builder.Build();

                // Configure the HTTP request pipeline.
                if (app.Environment.IsDevelopment())
                {
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }

                app.UseHttpsRedirection();

                app.UseAuthorization();

                app.MapControllers();

                app.Run();
            }
            catch (Exception exception)
            {
                logger.Error(exception, exception.Message);
                throw;
            }
            finally
            {
                //dispose nlog once complete
                NLog.LogManager.Shutdown();
            }
        }
    }
}