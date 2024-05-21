using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using SO.Integration.Client;
using SO.Integration.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient
{
	BaseAddress = builder.Configuration.GetValue<Uri>("HttpClient:Uri") ?? throw new NullReferenceException("HttpClient:Uri"),
	Timeout = builder.Configuration.GetValue<TimeSpan?>("HttpClient:Timeout") ?? TimeSpan.FromSeconds(100)
});
builder.Services.AddScoped<IFileTransformerHttpClient, FileTransformerHttpClient>();

builder.Services.AddMudServices();

await builder.Build().RunAsync();