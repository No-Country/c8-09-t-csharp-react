using Blazored.LocalStorage;
using TicketFanAdmin;
using TicketFanAdmin.Services;
using TicketFanAdmin.Services.Interfaces;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using Microsoft.AspNetCore.Components.Authorization;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped(c => new HttpClient
{
    BaseAddress = new Uri("https://cohorteapi.azurewebsites.net")
    //BaseAddress = new Uri("https://localhost:51969/")    
});
builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<EventService>();
builder.Services.AddMudServices();
await builder.Build().RunAsync();
