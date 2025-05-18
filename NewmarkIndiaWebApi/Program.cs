using NewmarkIndia.BusinessLogic.Classes;
using NewmarkIndia.BusinessLogic.Interfaces;
using NewmarkIndiaWebApi.Initializers;

var builder = WebApplication.CreateBuilder(args);

builder.RegisterBuildServices();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.RegisterApplicationServices(builder);
builder.Services.ConfigureCors();


var app = builder.Build();
app.UseCors();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ConfigureMiddleware();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
