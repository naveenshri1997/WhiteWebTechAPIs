
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WhiteWebTech.API;
using WhiteWebTech.API.DataAccess;

using WhiteWebTech.API.Entities;
using WhiteWebTech.API.Services;
using WhiteWebTech.API.Services.IServices;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAWSLambdaHosting(LambdaEventSource.RestApi);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<WhiteDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DBConnection")));

//mapper
IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Dependency
builder.Services.AddScoped(typeof(IGenericServices<>),typeof(GenericServices<>));
builder.Services.AddScoped(typeof(DbContext),typeof(WhiteDbContext));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors(option=>{
    option.AllowAnyOrigin();
    option.AllowAnyMethod();
    option.AllowAnyHeader();

});

//app.MapNewQueryEndpoints();

app.Run();
