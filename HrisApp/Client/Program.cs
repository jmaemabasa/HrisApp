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
global using HrisApp.Client.Services.MasterData.ManpowerService;
global using HrisApp.Client.Services.Payroll;
global using HrisApp.Client.Services.TokenService;
global using HrisApp.Client.Services.UserRole;
global using HrisApp.Shared.Models.Application;
global using HrisApp.Shared.Models.StaticData;
global using HrisApp.Shared.Models.Employee;
global using HrisApp.Shared.Models.Emp_Education;
global using HrisApp.Shared.Models.Emp_LiscenseAndTraining;
global using HrisApp.Client.Services.LeaveService;
global using HrisApp.Client.Services.StaticDataService.StaticService;
global using HrisApp.Client.Services.AuditlogService;
global using HrisApp.Client.Services.EmpDetails.EmpHistoryService;
global using HrisApp.Shared.Models.Images;
global using HrisApp.Shared.Models.MasterData;
global using HrisApp.Shared.Models.Emp_Payroll;
global using HrisApp.Shared.Models.User;
global using HrisApp.Shared.Models.Audit;
global using HrisApp.Shared.Models.App_Education;
global using HrisApp.Shared.Models.App_LiscenseAndTraining;
global using HrisApp.Shared.Models.Application.App_Family;
global using HrisApp.Shared.Models.Application.App_LiscenseAndTraining;
global using HrisApp.Shared.Models.Application.App_ProfBackground;
global using HrisApp.Client.Services.EmpDetails.EmpEvaluationService;
global using HrisApp.Client.Services.EmpDetails.LeaveCredService;
global using HrisApp.Client.Services.EmpDetails.LeaveHistoryService;
global using HrisApp.Client.HelperToken;
global using HrisApp.Client.Pages.Dialog;
global using HrisApp.Client.ViewModel;
global using HrisApp.Client.Pages.Dialog.Employee;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.AspNetCore.Components;
global using Microsoft.AspNetCore.Components.Authorization;
global using Microsoft.AspNetCore.Components.Forms;
global using Microsoft.AspNetCore.WebUtilities;
global using Microsoft.JSInterop;
global using MudBlazor;
global using MudBlazor.Services;
global using ChartJs.Blazor.BarChart;
global using ChartJs.Blazor.Common;
global using ChartJs.Blazor.Common.Axes;
global using ChartJs.Blazor.Common.Enums;
global using ChartJs.Blazor.LineChart;
global using ChartJs.Blazor.PieChart;
global using ChartJs.Blazor.Util;
global using System.Net.Http.Headers;
global using System.Net.Http.Json;
global using System.Security.Claims;
global using HrisApp.Client.GlobalService;
global using HrisApp.Client.ViewModel.AdminViewModel.AuditlogViewModel;
global using HrisApp.Client.ViewModel.EmployeeViewModel.EmployeeViewModel;
global using HrisApp.Client.ViewModel.MasterDataViewModel;
global using HrisApp.Client.Services.ApplicantDetails.AppAddressService;
global using HrisApp.Client.Services.ApplicantDetails.AppEducService;
global using HrisApp.Client.Services.ApplicantDetails.AppLicTrainingService;
global using HrisApp.Client.Services.ApplicantDetails.AppSibChildService;
global using HrisApp.Shared.Models.Announcement;
global using HrisApp.Client.Services.AnnouncementS;
global using HrisApp.Shared.Models.Attendance;
global using HrisApp.Client.Services.Attendance.AttendanceRecS;
global using HrisApp.Client.ViewModel.Templates;
global using HrisApp.Client.Services.Attendance.TimetableS;
global using HrisApp.Shared.Models.Assets;
global using HrisApp.Client.Services.Assets.AssetTypeService;
global using HrisApp.Client.Services.Assets.AssetCategoryService;
global using HrisApp.Client.Pages.Dialog.Assets.AssetCat;
global using HrisApp.Client.Pages.Dialog.Assets.AssetType;
global using HrisApp.Client.Services.Assets.AssetSubCategoryService;
global using HrisApp.Client.Services.Assets.AssetAccessoryService;
global using HrisApp.Client.Services.Assets.AssetMasterService;
global using HrisApp.Client.Services.Assets.MainAssetAccService;

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

//MVVM ni sir buds
builder.Services.AddScoped<IMainsService, MainsService>();

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
builder.Services.AddScoped<IEmpHistoryService, EmpHistoryService>();
builder.Services.AddScoped<IAuditlogService, AuditlogService>();
builder.Services.AddScoped<IStaticService, StaticService>();
builder.Services.AddScoped<IForEvalService, ForEvalService>();
builder.Services.AddScoped<IManpowerService, ManpowerService>();
builder.Services.AddScoped<ILeaveService, LeaveService>();
builder.Services.AddScoped<ILeaveCredService, LeaveCredService>();
builder.Services.AddScoped<ILeaveHistoryService, LeaveHistoryService>();
builder.Services.AddScoped<IAnnouncementService, AnnouncementService>();
builder.Services.AddScoped<IAttendanceRecService, AttendanceRecService>();
builder.Services.AddScoped<ITimetableService, TimetableService>();
builder.Services.AddScoped<IAssetTypeService, AssetTypeService>();
builder.Services.AddScoped<IAssetCategoryService, AssetCategoryService>();
builder.Services.AddScoped<IAssetSubCategoryService, AssetSubCategoryService>();
builder.Services.AddScoped<IAssetAccessoryService, AssetAccessoryService>();
builder.Services.AddScoped<IAssetMasterService, AssetMasterService>();
builder.Services.AddScoped<IMainAssetAccService, MainAssetAccService>();
builder.Services.AddTransient<GlobalConfigService>();
builder.Services.AddTransient<AuditlogGlobal>();
builder.Services.AddSingleton<StateService>();
builder.Services.AddTransient<BackUpDeletion>();
builder.Services.AddTransient<JMColors>();

builder.Services.AddTransient<DTOEmployeeExport>();
builder.Services.AddTransient<DTOEmpHeadcountExport>();
builder.Services.AddTransient<DTOEmployeeData>();

//TEMPLATES
builder.Services.AddTransient<AttendanceImportTemplate>();

//VIEWMODEL
builder.Services.AddTransient<AuditlogVM>();
builder.Services.AddTransient<EmployeeVM>();
builder.Services.AddTransient<AddEmployeeVM>();
builder.Services.AddTransient<AreaVM>();
builder.Services.AddTransient<DepartmentVM>();

//APPLICANT
builder.Services.AddScoped<IApplicantService, ApplicantService>();
builder.Services.AddScoped<IAppAddressService, AppAddressService>();
builder.Services.AddScoped<IAppEducService, AppEducService>();
builder.Services.AddScoped<IAppLicenseTrainingService, AppLicenseTrainingService>();
builder.Services.AddScoped<IAppSibChildService, AppSibChildService>();

//===========================//////////=======================

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();