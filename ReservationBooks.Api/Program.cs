
using Microsoft.EntityFrameworkCore;
using ReservationBooks.Infrastructure.Adapters.Mssql;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ReservationBooks.Api
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

            string? connection = builder.Configuration.GetConnectionString("Mssql");


            builder.Services.AddDbContext<MssqlDbContext>(options => options.UseSqlServer(connection));

  

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
        }
    }
}
