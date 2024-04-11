
using BankingRemoteApi.Data;
using BankingRemoteApi.Interfaces;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace BankingRemoteApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<BankingContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("BankingConnectionString")));


            // Add services to the container.

            // builder.Services.AddControllers();

            builder.Services.AddControllers().AddJsonOptions(x =>
                 x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

            builder.Services.AddScoped<IBankingRepository, BankingRepository>();
            builder.Services.AddTransient<DbInitialiser>();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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

            using var scope = app.Services.CreateScope();

            var services = scope.ServiceProvider;

            var initialiser = services.GetRequiredService<DbInitialiser>();

            initialiser.Run();


            app.Run();
        }
    }
}
