// using PortfolioBackend.Interfaces.Services;
// using PortfolioBackend.Services.Weather;

namespace PortfolioBackend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddScoped<IResponseBuilder, DefaultResponseBuilder>();
            builder.Services.AddScoped<IInputHandler, InputHandler>();

            builder.Services.AddScoped<IExpUpdateLines, ExpUpdateLines>();
            builder.Services.AddScoped<ITermUpdateLines, TermUpdateLines>();
            builder.Services.AddScoped<IFactorUpdateLines, FactorUpdateLines>();
            builder.Services.AddScoped<IPowerUpdateLines, PowerUpdateLines>();
            builder.Services.AddScoped<IFunctionUpdateLines, FunctionUpdateLines>();
            builder.Services.AddScoped<IDigitUpdateLines, DigitUpdateLines>();

            builder.Services.AddScoped<IExpressionParser, ExpressionParser>();
            builder.Services.AddScoped<CalculatorService>();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAngularApp",
                    policy =>
                    {
                        policy.WithOrigins("http://localhost:4200")
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });
            var app = builder.Build();

            // Use CORS BEFORE routing
            app.UseCors("AllowAngularApp");

            app.UseHttpsRedirection();
            app.MapControllers();
            app.Run();
        }
    }
}


// var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
// builder.Services.AddOpenApi();
// builder.Services.AddScoped<IWeatherService, WeatherService>();

// builder.Services.AddCors(options =>
// {
//     options.AddPolicy("AllowAngularDev", policy =>
//     {
//         policy.WithOrigins("http://localhost:4200")
//               .AllowAnyHeader()
//               .AllowAnyMethod();
//     });
// });

// var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.MapOpenApi();
// }

// app.UseCors("AllowAngularDev");
// app.UseHttpsRedirection();

// var summaries = new[]
// {
//     "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
// };

// app.MapGet("/weatherforecast", () =>
// {
//     var forecast =  Enumerable.Range(1, 5).Select(index =>
//         new WeatherForecast
//         (
//             DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//             Random.Shared.Next(-20, 55),
//             summaries[Random.Shared.Next(summaries.Length)]
//         ))
//         .ToArray();
//     return forecast;
// })
// .WithName("GetWeatherForecast");

// app.Run();

// record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
// {
//     public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
// }
