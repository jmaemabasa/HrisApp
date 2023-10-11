global using Blazored.LocalStorage;
global using MudBlazor.Services;
global using MudBlazor;
global using HrisApp.Shared.Models.User;
global using HrisApp.Client.Services.AuthService;
global using HrisApp.Client.Services.TokenService;
global using Microsoft.AspNetCore.Components.Authorization;
global using Microsoft.AspNetCore.Authorization;
using HrisApp.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//===========================//////////=======================
builder.Services.AddMudServices();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddOptions();
builder.Services.AddAuthentication();
builder.Services.AddAuthorizationCore();
builder.Services.AddBlazoredLocalStorage();
//===========================//////////=======================

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
