using GraphQLApi;
using GraphQLApi.Business;
using GraphQLApi.Business.Interfaces;
using GraphQLApi.Handlers;
using GraphQLApi.Handlers.Interfaces;
using GraphQLApi.Models.Context;
using GraphQLApi.Repositories;
using GraphQLApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutations>();

builder.Services.AddScoped<ITodoRepository, TodoRepository>();
builder.Services.AddScoped<ITaskValidatorBusiness, TaskValidatorBusiness>();
builder.Services.AddScoped<IUpsertTaskHandler, UpsertTaskHandler>();
builder.Services.AddScoped<IGetAllTaskHandler, GetAllTaskHandler>();
builder.Services.AddScoped<IGetByIdTaskHandler, GetByIdTaskHandler>();

builder.Services.AddDbContext<TodoContext>(options => options.UseInMemoryDatabase("TodoDatabase"));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapGraphQL();

app.Run();
