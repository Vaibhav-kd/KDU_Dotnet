using Assignment3.Models;
using Assignment3.services;
using Microsoft.EntityFrameworkCore;

namespace Assignment3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            var connectionString = builder.Configuration.GetConnectionString("Flight_Database_System");

            builder.Services.AddSqlServer<Flight_Database_SystemContext>(connectionString);
            builder.Services.AddScoped<AdminServices>();
            builder.Services.AddScoped<UserServices>();
            builder.Services.AddScoped<OperatorServices>();
            builder.Services.AddScoped<PassengerServices>();

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
        }
    }
}