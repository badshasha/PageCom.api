using Microsoft.AspNetCore.Mvc.RazorPages;
using PageCom.api.App.databasePreperation;
using PageCom.Api.Application.ExtendClasses;
using pageCom.api.Data.ExtendClass;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// extend services [+]
builder.Services.ApplicationExtendService();
builder.Services.PageComApiInfastructureExtenderInfo(builder.Configuration);

var app = builder.Build();
PrepData.DataBaseCreate(app); // database creating [+]

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