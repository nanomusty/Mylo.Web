using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using Mylo.Web;
using Mylo.Web.Base;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<BasePage>();
builder.Services.AddScoped<SessionInfo>();
builder.Services.AddHttpClient("Wasm", client =>
{
    client.BaseAddress = new Uri(builder.HostEnvironment.IsDevelopment() ? "https://localhost:44343/" : "https://nanomusty-001-site1.qtempurl.com/");
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddMudServices();

await builder.Build().RunAsync();
