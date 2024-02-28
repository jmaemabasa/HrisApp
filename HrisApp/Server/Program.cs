global using HrisApp.Server.Data;
global using HrisApp.Server.Services.UserService;
global using HrisApp.Shared.Models.Emp_Education;
global using HrisApp.Shared.Models.Employee;
global using HrisApp.Shared.Models.Images;
global using HrisApp.Shared.Models.Emp_LiscenseAndTraining;
global using HrisApp.Shared.Models.MasterData;
global using HrisApp.Shared.Models.Application;
global using HrisApp.Shared.Models.Emp_Payroll;
global using HrisApp.Shared.Models.User;
global using HrisApp.Shared.Models.StaticData;
global using HrisApp.Shared.Models.App_Education;
global using HrisApp.Shared.Models.App_LiscenseAndTraining;
global using HrisApp.Shared.Models.Application.App_Family;
global using HrisApp.Shared.Models.Application.App_LiscenseAndTraining;
global using HrisApp.Shared.Models.Application.App_ProfBackground;
global using Microsoft.EntityFrameworkCore;
global using MudBlazor.Services;
global using HrisApp.Shared.Models.Assets;
global using Microsoft.AspNetCore.Mvc;

using Blazored.Toast;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

//=================///////////////===========================
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddMudServices();
builder.Services.AddBlazoredToast();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor();
builder.Services.AddAuthenticationCore();
builder.Services.AddSweetAlert2();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey =
                new SymmetricSecurityKey(System.Text.Encoding.UTF8
                .GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

builder.Services.AddScoped<IUserService, UserService>();
//=================///////////////===========================
builder.Services.AddCors(options =>
{
    options.AddPolicy("MyPolicy", builder =>
    {
        builder.AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin();
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();
app.UseCors("MyPolicy");

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();