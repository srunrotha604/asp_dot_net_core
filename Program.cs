var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();
builder.Services.AddControllers();
var configuration = builder.Configuration;
var testValue = configuration["TestValue"];
var app = builder.Build();
app.MapGet("/", () => $"Hello World! Test Value: {testValue}");
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
