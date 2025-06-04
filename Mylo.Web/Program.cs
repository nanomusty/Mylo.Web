using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using Mylo.Web;
using Mylo.Web.Base;
using Mylo.Web.ObjectModels;
using System.Net.Http.Json;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// appsettings.json değerlerini oku
var configUrl = $"{builder.HostEnvironment.BaseAddress}appsettings.json";
var config = await new HttpClient().GetFromJsonAsync<ConfigurationModel>(configUrl);

builder.Logging.SetMinimumLevel(LogLevel.Warning);

builder.Services.AddScoped<BasePage>();
builder.Services.AddScoped<SessionInfo>();
builder.Services.AddHttpClient("Wasm", client =>
{
    client.BaseAddress = new Uri(builder.HostEnvironment.IsDevelopment() ? config.LocalApiUrl : config.ApiBaseUrl);
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddMudServices();

await builder.Build().RunAsync();
