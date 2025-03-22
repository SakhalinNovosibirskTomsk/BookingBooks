
using MediatR;
using Microsoft.EntityFrameworkCore;
using ReservationBooks.Core.Application.Ports;
using ReservationBooks.Core.Application.UseCases.Commands.Reserve;
using ReservationBooks.Infrastructure.Adapters.Mssql;
using ReservationBooks.Infrastructure.Adapters.Mssql.Repositories;
using System.Reflection;
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

            // Mediator
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            builder.Services.AddDbContext<MssqlDbContext>(options => options.UseSqlServer(connection));
            builder.Services.AddScoped<IBookInstanceRepository, BookInstanceRepository>();

            builder.Services.AddTransient<IRequestHandler<ReserveBookInstanceCommand, bool>, ReserveBookInstanceHandler>();


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
