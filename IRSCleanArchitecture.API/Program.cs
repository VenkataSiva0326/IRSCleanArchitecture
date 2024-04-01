using IRSCleanArchitecture.API.Extensions;
using IRSCleanArchitecture.Application.Services;
using IRSCleanArchitecture.Persistence;




var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigurePersistenceApp(builder.Configuration);
builder.Services.ConfigureApplication();
builder.Services.ConfigureCorsPolicy();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.Run();