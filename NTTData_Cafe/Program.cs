using Microsoft.EntityFrameworkCore;
using NTTData_Cafe.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<NTTDataDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("NTTDataDb")));

builder.Services.AddMediatR(configuration => {
  configuration.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
  options.AddPolicy("AllowReactApp", policy =>
  {
    policy.WithOrigins("http://localhost:3001")  // The URL of your React frontend
          .AllowAnyMethod()                     // Allows all HTTP methods (GET, POST, etc.)
          .AllowAnyHeader()                     // Allows any headers
          .AllowCredentials();                  // Allows cookies and credentials if needed
  });
});

var app = builder.Build();

app.UseCors("AllowReactApp");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
