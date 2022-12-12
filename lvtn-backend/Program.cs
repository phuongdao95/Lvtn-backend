using Models.Repositories;
using Models.Repositories.DataContext;
using Microsoft.EntityFrameworkCore;
using Services.Contracts;
using Services.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Models.Helpers;
using lvtn_backend.Middleware;
using lvtn_backend.Hubs;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyMethod()
            .SetIsOriginAllowed(origin => true) // allow any origin
            .AllowAnyHeader()
            .AllowCredentials();
    });
});

builder.Services.AddControllers();
builder.Services.AddSignalR();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add database context
builder.Services.AddDbContext<EmsContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("EmsConnectionString"),
        b => b.MigrationsAssembly("Repositories")
    );
});
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Authentication and Authorization
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidAudience = builder.Configuration["Jwt:Audience"],
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };

        options.Events = new JwtBearerEvents()
        {
            OnMessageReceived = context =>
            {
                var accessToken = context.Request.Query["access_token"];
                var path = context.HttpContext.Request.Path;
                context.Token = accessToken;

                return Task.CompletedTask;
            }

        };
    });

builder.Services.AddAuthorization((options) =>
{
    var claimNames = ClaimGenerator.GenerateResourceAccessClaims();

    claimNames.ForEach((name) =>
    {
        options.AddPolicy(name, policy => policy.RequireClaim(name));
    });
});

// Add repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITeamRepository, TeamRepository>();

// Add services
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<ITeamService, TeamService>();
builder.Services.AddScoped<IAiService, AiService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IPermissionService, PermissionService>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<ISalaryDeltaService, SalaryDeltaService>();
builder.Services.AddScoped<PayrollService, PayrollService>();
builder.Services.AddScoped<SalaryFormulaService, SalaryFormulaService>();
builder.Services.AddScoped<GroupService, GroupService>();
builder.Services.AddScoped<SalaryGroupService, SalaryGroupService>();
builder.Services.AddScoped<SalaryCalculatorService, SalaryCalculatorService>();
builder.Services.AddScoped<TaskService, TaskService>();
builder.Services.AddScoped<TaskBoardService, TaskBoardService>();
builder.Services.AddScoped<TaskHistoryService, TaskHistoryService>();
builder.Services.AddScoped<IdentityService, IdentityService>();
builder.Services.AddScoped<IdentityService, IdentityService>();
builder.Services.AddScoped<NotificationService, NotificationService>();
builder.Services.AddScoped<WorkingShiftService, WorkingShiftService>();
builder.Services.AddScoped<WorkingShiftTimekeepingService, WorkingShiftTimekeepingService>();
// Add AutoMapper Configuration
builder.Services.AddAutoMapper(typeof(Program));

//builder.Services.AddSpaStaticFiles(
//    configuration =>
//{
//    configuration.RootPath = "ClientApp/Lvtn-frontend/build";
//});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}

app.UseStaticFiles();

app.UseRouting();
app.UseCors();

app.UseAuthentication();
app.UseMiddleware<ClaimMiddleware>();
app.UseAuthorization();

app.MapControllers();
app.MapHub<NotificationHub>("/notification");

//app.UseSpa((spa) =>
//{
//    spa.Options.SourcePath = "ClientApp/Lvtn-frontend/";

//    if (app.Environment.IsDevelopment())
//    {
//        spa.UseReactDevelopmentServer(npmScript: "start");
//    }
//});

app.Run();
