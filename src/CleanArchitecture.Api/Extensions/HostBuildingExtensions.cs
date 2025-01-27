using Asp.Versioning;
using CleanArchitecture.Api.Middlewares;
using CleanArchitecture.Application;
using CleanArchitecture.Infrastructure;
using FluentValidation;
using FluentValidation.AspNetCore;
using Scalar.AspNetCore;

namespace CleanArchitecture.Api.Extensions;

public static class HostBuildingExtensions
{
    public static WebApplication AddServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();
        builder.Services.AddOpenApi();
        builder.Services.AddHealthChecks();
        builder.Services.AddProblemDetails();
        builder.Services.AddValidatorsFromAssembly(typeof(HostBuildingExtensions).Assembly);
        builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(policy =>
            {
                policy.AllowAnyOrigin()
                      .AllowAnyHeader()
                      .AllowAnyMethod();
            });
        });

        builder.Services.AddApiVersioning(options =>
        {
            options.DefaultApiVersion = new ApiVersion(1, 0);
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.ReportApiVersions = true;
            options.ApiVersionReader = new UrlSegmentApiVersionReader();
        }).AddApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'VVV";
            options.SubstituteApiVersionInUrl = true;
        });

        builder.Services.AddFluentValidationAutoValidation(config =>
        {
            config.DisableDataAnnotationsValidation = true;

        }).AddFluentValidationClientsideAdapters();

        builder.Services.AddAuthorization();
        builder.Services.AddAuthentication();
        builder.Services
            .AddApplicationServices(builder.Configuration)
            .AddInfrastructureServices(builder.Configuration);

        return builder.Build();
    }

    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.MapScalarApiReference(options =>
            {
                options.WithTitle("My API");
                options.WithTheme(ScalarTheme.Mars);
                options.WithSidebar(true);
                options.DefaultHttpClient = new(ScalarTarget.Http, ScalarClient.Http11);
            });
        }

        app.UseMiddleware<ErrorHandlerMiddleware>();
        app.UseCors();
        app.UseRouting();
        app.MapControllers();
        app.UseHealthChecks("/healthz");

        return app;
    }
}

