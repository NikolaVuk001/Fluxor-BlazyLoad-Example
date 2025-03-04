using Fluxor;
using Fluxor.Blazor.Web.ReduxDevTools;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using RonSijm.Blazyload.Features.Bootstapping;
using RonSijm.Blazyload.Features.DIComponents;
using Test.App;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// builder.UseBlazyload();

// builder.Services.AddScoped<BlazyAssemblyLoader>();


builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Fluxor 
var currAssembly = typeof(Program).Assembly;
builder.Services.AddFluxor(options =>
{
    options.ScanAssemblies(currAssembly);
    options.ScanAssemblies(typeof(Test.Store.WeatherStore.WeatherState).Assembly);
#if DEBUG
    options.UseReduxDevTools();
#endif
});

// Module Services
builder.Services.AddScoped<Test.Store.WeatherStore.Services.WeatherStateService>();

await builder.Build().RunAsync();
