await WebApplication.CreateBuilder(args)
    .AddServices()
    .ConfigurePipeline()
    .RunAsync();

