global using Blazored.LocalStorage;
global using Blazored.Toast;
global using CurrieTechnologies.Razor.SweetAlert2;
global using HrisApp.Client.Global;
global using HrisApp.Client.Pages.Dialog.MasterData;
global using HrisApp.Client.Services.ApplicantDetails.ApplicantService;
global using HrisApp.Client.Services.AuthService;
global using HrisApp.Client.Services.EmpDetails.AddressService;
global using HrisApp.Client.Services.EmpDetails.EducationService;
global using HrisApp.Client.Services.EmpDetails.EmployeeService;
global using HrisApp.Client.Services.EmpDetails.EmploymentDateService;
global using HrisApp.Client.Services.ImageService;
global using HrisApp.Client.Services.LicAndTrainService;
global using HrisApp.Client.Services.MasterData.AreaService;
global using HrisApp.Client.Services.MasterData.DepartmentService;
global using HrisApp.Client.Services.MasterData.DivisionService;
global using HrisApp.Client.Services.MasterData.PositionService;
global using HrisApp.Client.Services.MasterData.ScheduleService;
global using HrisApp.Client.Services.MasterData.SectionService;
global using HrisApp.Client.Services.Payroll;
global using HrisApp.Client.Services.TokenService;
global using HrisApp.Client.Services.UserRole;
global using HrisApp.Shared.Models.Application;
global using HrisApp.Shared.Models.StaticData;
global using HrisApp.Shared.Models.Employee;
global using HrisApp.Shared.Models.Emp_Education;
global using HrisApp.Shared.Models.Emp_LiscenseAndTraining;
global using HrisApp.Client.Services.StaticDataService.StaticService;
global using HrisApp.Client.Services.AuditlogService;
global using HrisApp.Shared.Models.Images;
global using HrisApp.Shared.Models.MasterData;
global using HrisApp.Shared.Models.Emp_Payroll;
global using HrisApp.Shared.Models.User;
global using HrisApp.Shared.Models.Audit;
global using HrisApp.Client.HelperToken;
global using HrisApp.Client.Pages.Dialog;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.AspNetCore.Components;
global using Microsoft.AspNetCore.Components.Authorization;
global using Microsoft.AspNetCore.Components.Forms;
global using Microsoft.AspNetCore.WebUtilities;
global using Microsoft.JSInterop;
global using MudBlazor;
global using MudBlazor.Services;
global using System.Net.Http.Headers;
global using System.Net.Http.Json;
global using System.Security.Claims;
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
builder.Services.AddScoped<ILicenseTrainingService, LicenseTrainingService>();
builder.Services.AddScoped<IPayrollService, PayrollService>();
builder.Services.AddScoped<IScheduleService, ScheduleService>();
builder.Services.AddScoped<IUserRoleService, UserRoleService>();
builder.Services.AddScoped<IEmploymentDateService, EmploymentDateService>();
builder.Services.AddScoped<IAuditlogService, AuditlogService>();
builder.Services.AddScoped<IStaticService, StaticService>();
builder.Services.AddTransient<GlobalConfigService>();
builder.Services.AddTransient<AuditlogGlobal>();
builder.Services.AddSingleton<StateService>();


builder.Services.AddScoped<IApplicantService, ApplicantService>();

//===========================//////////=======================

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
