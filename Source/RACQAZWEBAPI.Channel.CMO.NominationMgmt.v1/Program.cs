using Boxed.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Core;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace RACQAZWEBAPI.Channel.CMO.NominationMgmt.v1.API
{
    public sealed class Program
    {
        public static Task<int> Main(string[] args)
        {
            return LogAndRunAsync(CreateHostBuilder(args).Build());
        }

        public static async Task<int> LogAndRunAsync(IHost host)
        {
            // Use the W3C Trace Context format to propagate distributed trace identifiers.
            // See https://devblogs.microsoft.com/aspnet/improvements-in-net-core-3-0-for-troubleshooting-and-monitoring-distributed-apps/
            Activity.DefaultIdFormat = ActivityIdFormat.W3C;

            Log.Logger = CreateLogger(host);

            try
            {
                Log.Information("Started application");
                await host.RunAsync().ConfigureAwait(false);
                Log.Information("Stopped application");
                return 0;
            }
#pragma warning disable CA1031 // Do not catch general exception types
            catch (Exception exception)
#pragma warning restore CA1031 // Do not catch general exception types
            {
                Log.Fatal(exception, "Application terminated unexpectedly");
                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return new HostBuilder()
                //
                .UseContentRoot(Directory.GetCurrentDirectory())
                .ConfigureHostConfiguration(
                    configurationBuilder => configurationBuilder
                        .AddEnvironmentVariables("DOTNET_")
                        .AddIf(
                            args != null,
                            x => x.AddCommandLine(args)))
                .ConfigureAppConfiguration((hostingContext, config) =>
                    AddConfiguration(config, hostingContext.HostingEnvironment, args))
                .UseSerilog()
                .UseDefaultServiceProvider(
                    (context, options) =>
                    {
                        var isDevelopment = context.HostingEnvironment.IsDevelopment();
                        options.ValidateScopes = isDevelopment;
                        options.ValidateOnBuild = isDevelopment;
                    })
                .ConfigureWebHost(ConfigureWebHostBuilder)
                .UseConsoleLifetime();
        }

        private static void ConfigureWebHostBuilder(IWebHostBuilder webHostBuilder)
        {
            webHostBuilder
                //.UseApplicationInsights()
                .UseSerilog()
                .UseKestrel((builderContext, options) => options.AddServerHeader = false)
                .UseAzureAppServices()
                // Used for IIS and IIS Express for in-process hosting. Use UseIISIntegration for out-of-process hosting.
                .UseIIS()

                //.ConfigureAppConfiguration((context, config) =>
                //{
                //    var configBuilt = config.Build();

                //    //Create Managed Service Identity token provider
                //    var tokenProvider = new AzureServiceTokenProvider();

                //    //Create the Key Vault client
                //    var kvClient = new KeyVaultClient((authority, resource, scope) => tokenProvider.KeyVaultTokenCallback(authority, resource, scope));

                //    //Add Key Vault to configuration pipeline
                //    _ = config.AddAzureKeyVault(configBuilt["KeyVault:BaseUrl"], kvClient, new DefaultKeyVaultSecretManager());
                //})

                .UseStartup<Startup>();
        }

        private static IConfigurationBuilder AddConfiguration(
            IConfigurationBuilder configurationBuilder,
            IHostEnvironment hostEnvironment,
            string[] args)
        {
            return configurationBuilder
                // Add configuration from the appsettings.json file.
                .AddJsonFile("appsettings.json", true, false)
                // Add configuration from an optional appsettings.development.json, appsettings.staging.json or
                // appsettings.production.json file, depending on the environment. These settings override the ones in
                // the appsettings.json file.
                .AddJsonFile($"appsettings.{hostEnvironment.EnvironmentName}.json", true, false)
                // Add configuration from files in the specified directory. The name of the file is the key and the
                // contents the value.
                .AddKeyPerFile(Path.Combine(Directory.GetCurrentDirectory(), "configuration"), true)
                // This reads the configuration keys from the secret store. This allows you to store connection strings
                // and other sensitive settings, so you don't have to check them into your source control provider.
                // Only use this in Development, it is not intended for Production use. See
                // http://docs.asp.net/en/latest/security/app-secrets.html
                .AddIf(
                    hostEnvironment.IsDevelopment() && !string.IsNullOrEmpty(hostEnvironment.ApplicationName),
                    x => x.AddUserSecrets(Assembly.GetExecutingAssembly(), true))
                // Add configuration specific to the Development, Staging or Production environments. This config can
                // be stored on the machine being deployed to or if you are using Azure, in the cloud. These settings
                // override the ones in all of the above config files. See
                // http://docs.asp.net/en/latest/security/app-secrets.html
                .AddEnvironmentVariables()
                // Push telemetry data through the Azure Application Insights pipeline faster in the development and
                // staging environments, allowing you to view results immediately.
                .AddApplicationInsightsSettings(!hostEnvironment.IsProduction())
                // Add command line options. These take the highest priority.
                .AddIf(
                    args != null,
                    x => x.AddCommandLine(args));
        }

        private static Logger CreateLogger(IHost host)
        {
            return new LoggerConfiguration()
                .ReadFrom.Configuration(host.Services.GetRequiredService<IConfiguration>())
                .Enrich.WithProperty("Application", GetAssemblyProductName())
                .Enrich.FromLogContext()
                .CreateLogger();
        }

        private static string GetAssemblyProductName()
        {
            return CustomAttributeExtensions
                .GetCustomAttribute<AssemblyProductAttribute>(Assembly.GetExecutingAssembly()).Product;
        }
    }
}