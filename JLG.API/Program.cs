using JLG.BizLogics;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var policyName = "corsapp";
// Add services to the container.

Console.OutputEncoding = Encoding.UTF8;

Console.WriteLine($"FINVAL Program builder.Environment.EnvironmentName: {builder.Environment.EnvironmentName}");

builder.Services.AddControllers();

builder.Services.AddCors(p => p.AddPolicy(policyName, builder =>
{
  builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

builder.Services.AddControllers();

builder.Services.AddSingleton<ITodoService, TodoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseCors(policyName);
//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
