using AutoTrading.Api;
using AutoTrading.Api.Utilities;
using AutoTrading.Application;
using AutoTrading.Infrastructure;
using AutoTrading.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Add Services to the container.
builder.Services.AddKeyVaultIfConfigured(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(AppSettings.Instance.AutoTrading.ConnectionString);
builder.Services.AddWebServices();
builder.Services.AddAuthentication(AppSettings.Instance.Jwt);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //await app.InitializeDatabaseAsync();
}
else
{
    app.UseHsts();
}

app.UseHealthChecks("/health");
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSwaggerUi(settings =>
{
    settings.Path = "/api";
    settings.DocumentPath = "/api/specification.json";
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapRazorPages();

app.MapFallbackToFile("index.html");

app.UseExceptionHandler(options => { });

app.Map("/", () => Results.Redirect("/api"));

app.UseAuthorization();
app.UseAuthentication();

app.MapEndPoints();

app.Run();

public partial class Program
{
}