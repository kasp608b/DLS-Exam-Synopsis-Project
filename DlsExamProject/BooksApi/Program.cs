using BooksApi;
using BooksApi.Models;
using Common;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<BookDatabaseSettings>(
    builder.Configuration.GetSection("BookDatabase"));

builder.Services.AddSingleton<BookDatabaseService>();

builder.Services.AddSingleton<IConverter<Book, BookDto>, BookConverter>();

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
