using System.Reflection;
using System.Text.Json.Serialization;
using Blog.Api.Context;
using Blog.Api.Repository;
using Blog.Api.Repository.Implementation;
using Blog.Api.Util;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(x => {
        x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(config => {
    config.SwaggerDoc("v1",
    new OpenApiInfo {
        Title = "Blog API",
        Version = "V1.0",
        Description = "This API can be utilized to create a simple blog.",
        Contact = new OpenApiContact {
            Name = "Pedro Lucas Bruno",
            Email = "pedro.lucas.bruno@hotmail.com"
        }
    });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    config.IncludeXmlComments(xmlPath);
});

// Dependency Injection to instances management.
builder.Services.AddScoped<IBaseRepository, BaseRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<IPublicationRepository, PublicationRepository>();

// Add AutoMapper configuration.
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

// Context and Connections with database services.
string mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<BlogApiContext>(options => options.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection)));

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

app.Run();
