using PompProperties.Application;
using PompProperties.Infrastructure;
using PompProperties.WebUI.Components;
using Syncfusion.Blazor;

try
{

    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();

    builder.Services.AddRazorComponents()
        .AddInteractiveServerComponents();
    builder.Services.AddSyncfusionBlazor();

    //Add project layers
    builder.Services.AddApplication();
    builder.Services.AddInfrastructure();
    //builder.Services.AddDomain();

    builder.Services.AddLogging(loggingBuilder =>
    {
        loggingBuilder.ClearProviders();
    });

    var app = builder.Build();

    Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzA5NTcyNEAzMjM0MmUzMDJlMzBuM0Ruc2NpRkNUaEgveVh3NVFEL3M1aFFHR0dvVEFCbFpRQ3NDa0ZXZmRBPQ==");

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Error", createScopeForErrors: true);
    }

    //add HTTP Client

    app.UseStaticFiles();
    app.UseAntiforgery();
    app.MapRazorComponents<App>()
        .AddInteractiveServerRenderMode();
    app.MapControllers();

    app.Run();

}
catch (Exception exception)
{
    throw;
}
finally
{
}