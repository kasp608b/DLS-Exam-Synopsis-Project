
using AuthorsApi;
using AuthorsApi.Models;
using Common;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<AuthorDatabaseSettings>(
    builder.Configuration.GetSection("AuthorDatabase"));

builder.Services.AddSingleton<AuthorDatabaseService>();

builder.Services.AddSingleton<IConverter<Author, AuthorDto>, AuthorConverter>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
