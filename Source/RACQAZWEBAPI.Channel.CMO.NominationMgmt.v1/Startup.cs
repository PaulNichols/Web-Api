using Boxed.AspNetCore;
using CorrelationId;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RACQAZ.Channel.CMO.NominationMgmt.v1.API.Constants;
using RACQAZWEBAPI.Platform.ErrorHandling;
using Serilog.Core.Enrichers;
using Serilog.Enrichers.AspNetCore.HttpContext;
using System.Reflection;

namespace RACQAZWEBAPI.Channel.CMO.NominationMgmt.v1.API
{
    /// <summary>
    ///     The main start-up class for the application.
    /// </summary>
    public class Startup
    {
        private readonly IConfiguration configuration;
        private readonly IWebHostEnvironment webHostEnvironment;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Startup" /> class.
        /// </summary>
        /// <param name="configuration">
        ///     The application configuration, where key value pair settings are stored. See
        ///     http://docs.asp.net/en/latest/fundamentals/configuration.html
        /// </param>
        /// <param name="webHostEnvironment">
        ///     The environment the application is running under. This can be Development,
        ///     Staging or Production by default. See http://docs.asp.net/en/latest/fundamentals/environments.html
        /// </param>
        public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            this.configuration = configuration;
            this.webHostEnvironment = webHostEnvironment;
        }

        /// <summary>
        ///     Configures the services to add to the ASP.NET Core Injection of Control (IoC) container. This method gets
        ///     called by the ASP.NET runtime. See
        ///     http://blogs.msdn.com/b/webdev/archive/2014/06/17/dependency-injection-in-asp-net-vnext.aspx
        /// </summary>
        public virtual void ConfigureServices(IServiceCollection services)
        {
            services
                 // Register LazyCache - makes the IAppCache implementation
                 // CachingService available to your code
                 .AddLazyCache()
                // Add Azure Application Insights data collection services to the services container.
                .AddApplicationInsightsTelemetry(configuration)
                .AddCorrelationIdFluent()
                .AddCustomCaching()
                .AddCustomCors()
                .AddCustomOptions(configuration)
                .AddCustomRouting()
                .AddResponseCaching()
                .AddCustomResponseCompression(configuration)
                .AddCustomStrictTransportSecurity()
                .AddCustomHealthChecks()
                .AddCustomSwagger()
                .AddHttpContextAccessor()
                // Add useful interface for accessing the ActionContext outside a controller.
                .AddSingleton<IActionContextAccessor, ActionContextAccessor>()
                .AddCustomApiVersioning()
                .AddServerTiming()
                .AddControllers()
                .AddCustomJsonOptions(webHostEnvironment)
                .AddCustomMvcOptions(configuration)
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()))
                .SetCompatibilityVersion(CompatibilityVersion.Latest)
                .UseCustomInvalidModelStateErrorMiddleware()
                .Services
                    .AddProjectServices()
                    .AddProjectCommands()
                    .AddProjectMappers();
        }

        /// <summary>
        ///     Configures the application and HTTP request pipeline. Configure is called after ConfigureServices is
        ///     called by the ASP.NET runtime.
        /// </summary>
        public virtual void Configure(IApplicationBuilder application)
        {
            application
                .UseCorrelationId(new CorrelationIdOptions { UpdateTraceIdentifier = false })
                .UseSerilogLogContext(options => options.EnrichersForContextFactory = context => new[]
                {
                    new PropertyEnricher("CorrelationId", context.GetXCorrelationId())
                })
                .UseIf(
                    webHostEnvironment.IsDevelopment(),
                    x => x.UseServerTiming())
                .UseForwardedHeaders()
                .UseResponseCaching()
                .UseResponseCompression()
                .UseIf(
                    !webHostEnvironment.IsDevelopment(),
                    x => x.UseHsts())
                //.UseIf(
                //    this.webHostEnvironment.IsDevelopment(),
                //    x => x.UseDeveloperExceptionPage())
                .UseRouting()
                .UseCors(CorsPolicyName.AllowAny)
                .UseCustomErrorMiddleware()
                .UseStaticFilesWithCacheControl()
                .UseCustomSerilogRequestLogging()
                .UseEndpoints(
                    builder =>
                    {
                        builder.MapControllers().RequireCors(CorsPolicyName.AllowAny);
                        builder
                            .MapHealthChecks("/status")
                            .RequireCors(CorsPolicyName.AllowAny);
                        builder
                            .MapHealthChecks("/status/self", new HealthCheckOptions { Predicate = _ => false })
                            .RequireCors(CorsPolicyName.AllowAny);
                    })
                .UseSwagger()
                .UseCustomSwaggerUI();
        }
    }
}