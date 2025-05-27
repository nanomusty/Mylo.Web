using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using Mylo.Web;
using Mylo.Web.Base;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(builder.HostEnvironment.IsDevelopment() ? "https://localhost:44343/" : "https://www.mylolaw.work")
});

builder.Services.AddScoped<BasePage>();

builder.Services.AddMudServices();

await builder.Build().RunAsync();
