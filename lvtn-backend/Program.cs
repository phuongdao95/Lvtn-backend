using lvtn_backend.Repositories;
using lvtn_backend.Repositories.DataContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Services.Contracts;
using Services.Services;

var builder = WebApplication.CreateBuilder(args);
var AllowClientOrigins = "_allowClientOrigins";

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllowClientOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:3000");
                      });
});

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

// Add repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITeamRepository, TeamRepository>();

// Add services
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<ITeamService, TeamService>();

// Add AutoMapper Configuration
builder.Services.AddAutoMapper(typeof(Program));

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

app.UseCors(AllowClientOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
