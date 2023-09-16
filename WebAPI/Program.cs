using Application.Interfaces;
using Application.Services;
using Application.Utilities.Mapping;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using WebAPI.Middlewares;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<LibraryDbContext>(x => x.UseSqlite("Data Source=library.db;"));

            builder.Services.AddScoped<IBaseRepository<Book>, BookRepository>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            var mapperConfig = new MapperConfiguration(mc => mc.AddProfile(new AutomapperProfile()));
            IMapper mapper = mapperConfig.CreateMapper();
            builder.Services.AddSingleton(mapper);

            builder.Services.AddScoped<IBookService, BookService>();

            builder.Services.AddTransient<ErrorHandlerMiddleware>();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(builder =>
                builder
                    .AllowAnyHeader()
                    .AllowAnyOrigin()
                    .AllowAnyMethod());
            app.UseMiddleware<ErrorHandlerMiddleware>();

            app.MapControllers();

            using (var scope = app.Services.CreateAsyncScope())
            {
                var services = scope.ServiceProvider;
                DataSeeder.Run(services).Wait();
            }

            app.Run();
        }
    }
}