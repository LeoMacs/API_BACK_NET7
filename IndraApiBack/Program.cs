using IndraApiBack.BusinessLogic.interfaces;
using IndraApiBack.BusinessLogic.services;
using IndraApiBack.DataAccess.Data;
using IndraApiBack.DataAccess.Implementacion;
using IndraApiBack.DataAccess.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//////////////////////////////////////////
builder.Services.AddSingleton<ConexionService>();
//////////////////////////////////////////
builder.Services.AddSingleton<IEmpresaServices,EmpresaServices>();
builder.Services.AddSingleton<IEmpresa, EmpresaDA>();
//////////////sE PERMITE QUE SE SOLICITEN SOLICITUDES DESDE TAL IP////////////////////
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.WithOrigins("http://localhost:4200") // Orígenes permitidos
                   .AllowAnyMethod() // Métodos permitidos (GET, POST, PUT, DELETE, etc.)
                   .AllowAnyHeader(); // Encabezados permitidos
        });
});


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.WithOrigins("http://localhost:4200") // Orígenes permitidos
                   .AllowAnyMethod() // Métodos permitidos (GET, POST, PUT, DELETE, etc.)
                   .AllowAnyHeader(); // Encabezados permitidos
        });
});
//////////////////////////////////////////
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//var summaries = new[]
//{
//    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
//};

//app.MapGet("/weatherforecast", () =>
//{
//    var forecast = Enumerable.Range(1, 5).Select(index =>
//        new WeatherForecast
//        (
//            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//            Random.Shared.Next(-20, 55),
//            summaries[Random.Shared.Next(summaries.Length)]
//        ))
//        .ToArray();
//    return forecast;
//})
//.WithName("GetWeatherForecast")
//.WithOpenApi();


//////////PARA LOS CONTROLADORES//////////////
app.UseAuthorization();
app.MapControllers();
////////////PARA EL FRONT/////////////
app.UseCors("AllowSpecificOrigin");



app.Run();

//internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
//{
//    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
//}
