using lvtn_backend.DataContext;
using lvtn_backend.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add database context
builder.Services.AddDbContext<EmsContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("EmsConnectionString"));
});
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Add repository
builder.Services.AddScoped<IUserRepository, UserRepository>();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
