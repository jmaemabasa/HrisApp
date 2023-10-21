global using Microsoft.AspNetCore.Components;
global using Blazored.LocalStorage;
global using CurrieTechnologies.Razor.SweetAlert2;
global using HrisApp.Client.Pages.Dialog.MasterData;
global using HrisApp.Client.Services.AuthService;
global using HrisApp.Client.Services.MasterData.DepartmentService;
global using HrisApp.Client.Services.MasterData.DivisionService;
global using HrisApp.Client.Services.MasterData.SectionService;
global using HrisApp.Client.Services.MasterData.PositionService;
global using HrisApp.Client.Services.MasterData.AreaService;
global using HrisApp.Client.Services.EmpDetails.EmployeeService;
global using HrisApp.Client.Services.EmpDetails.AddressService;
global using HrisApp.Client.Services.EmpDetails.EducationService;
global using HrisApp.Shared.Models.Education;
global using HrisApp.Client.Services.ImageService;
global using HrisApp.Client.Services.TokenService;
global using HrisApp.Shared.Models.MasterData;
global using HrisApp.Shared.Models.User;
global using HrisApp.Shared.Models.Employee;
global using HrisApp.Shared.Models.Images;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.AspNetCore.Components.Authorization;
global using Microsoft.AspNetCore.WebUtilities;
global using MudBlazor;
global using MudBlazor.Services;
global using Blazored.Toast;
global using System.Net.Http.Json;
using HrisApp.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

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
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<ISectionService, SectionService>();
builder.Services.AddScoped<IPositionService, PositionService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IAreaService, AreaService>();
builder.Services.AddScoped<IAddressService, AddressService>();
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddScoped<IEducationService, EducationService>();

builder.Services.AddMudServices(config =>
{
    config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomLeft;

    config.SnackbarConfiguration.PreventDuplicates = false;
    config.SnackbarConfiguration.NewestOnTop = false;
    config.SnackbarConfiguration.ShowCloseIcon = true;
    config.SnackbarConfiguration.VisibleStateDuration = 10000;
    config.SnackbarConfiguration.HideTransitionDuration = 500;
    config.SnackbarConfiguration.ShowTransitionDuration = 500;
    config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
});

//===========================//////////=======================

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
