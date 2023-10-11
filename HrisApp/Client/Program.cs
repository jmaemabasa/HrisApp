global using HrisApp.Shared.Models.MasterData;
global using HrisApp.Client.Pages.Dialog.MasterData;
global using Blazored.LocalStorage;
global using CurrieTechnologies.Razor.SweetAlert2;
global using MudBlazor.Services;
global using MudBlazor;
global using Microsoft.AspNetCore.WebUtilities;
global using HrisApp.Shared.Models.User;
global using HrisApp.Client.Services.AuthService;
global using HrisApp.Client.Services.TokenService;
global using Microsoft.AspNetCore.Components.Authorization;
global using Microsoft.AspNetCore.Authorization;
global using HrisApp.Client.Services.MasterData.DivisionService;

using HrisApp.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazored.Toast;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//===========================//////////=======================
builder.Services.AddMudServices();
builder.Services.AddOptions();
builder.Services.AddAuthentication();
builder.Services.AddAuthorizationCore();
builder.Services.AddBlazoredLocalStorage();

builder.Services.AddSweetAlert2();
builder.Services.AddBlazoredToast();

builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ITokensService, TokensService>();
builder.Services.AddScoped<IDivisionService, DivisionService>();

//===========================//////////=======================

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
