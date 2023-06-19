using BooksApi;
using BooksApi.Models;
using Common;

var builder = WebApplication.CreateBuilder(args);

if (Environment.GetEnvironmentVariable("GREETING_FEATURE_FLAG") == "true")
{
    Console.WriteLine("Greeting feature flag is enabled");
}
else
{
    Console.WriteLine("Greeting feature flag is disabled");
}

string authorServiceBaseUrl = "http://authorsapi/api/Authors/";
// Add services to the container.
builder.Services.Configure<BookDatabaseSettings>(
    builder.Configuration.GetSection("BookDatabase"));

builder.Services.AddSingleton<BookDatabaseService>();

builder.Services.AddSingleton<IConverter<Book, BookDto>, BookConverter>();

builder.Services.AddSingleton(new
    AuthorsServiceGateway(authorServiceBaseUrl));

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
