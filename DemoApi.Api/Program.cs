using MultiValidation;
using DemoApi.Api;
using DemoApi.Api.Extensions;
using DemoApi.WorkFlows;
using DemoApi.Domain;
using DemoApi.DomainServices;
using DemoApi.Database;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApi();
builder.Services.AddDomain();
builder.Services.AddDomainServices();
builder.Services.AddWorkFlowServices();
builder.Services.AddDatabase(builder.Configuration.GetConnectionString("DataStorage"));
builder.Services.AddMultiValidation();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSingleton<GlobalExceptionHandler>();

builder.Services.AddSwagger();

var app = builder.Build();

app.UseGlobalExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
