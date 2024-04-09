using IRSCleanArchitecture.API.Extensions;
using IRSCleanArchitecture.Application.Services;
using IRSCleanArchitecture.Persistence;
using IRSCleanArchitecture.API.Middleware;





var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigurePersistenceApp(builder.Configuration);
builder.Services.ConfigureApplication();
builder.Services.ConfigureCorsPolicy();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddProblemDetails(options =>
{
    options.CustomizeProblemDetails = ctx =>
    {
        ctx.ProblemDetails.Extensions.Add("AdditionalInfo", "Additional Info Example");
        ctx.ProblemDetails.Extensions.Add("Server", Environment.MachineName);
        ctx.ProblemDetails.Extensions.Add("trace-id", ctx.HttpContext.TraceIdentifier);
        ctx.ProblemDetails.Extensions.Add("instance", $"{ctx.HttpContext.Request.Method} {ctx.HttpContext.Request.Path}");
    };
});
var app = builder.Build();

app.UseContentTypeValidation(); // for status code 415

app.UseCustomExceptionHandler(); // for validating custom exceptions
//app.UseExceptionHandler(); // when we are using custom exception handler middleware don't use this

app.UseStatusCodePages();
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.Run();