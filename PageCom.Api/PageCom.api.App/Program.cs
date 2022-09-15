using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;
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


// authentication  TODO add to infastructure class lib


var HOST = Environment.GetEnvironmentVariable("ID4HOST");
var PORT = Environment.GetEnvironmentVariable("ID4PORT");


builder.Services.AddAuthentication("bearer").AddJwtBearer("bearer", options =>
{
    // options.Authority = "https://localhost:7100";
    options.Authority = (HOST != null) ? $"http://{HOST}:{PORT}":"https://localhost:7100";
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateAudience = false
    };
    options.RequireHttpsMetadata = false;

});


// builder.Services.AddAuthorization(options =>
// {
//     options.AddPolicy("bookPolicy",policy => policy.RequireClaim("client_id",""));
// })

var app = builder.Build();
PrepData.DataBaseCreate(app); // database creating [+]

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();