using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.Repository;
using ApplicationCore.Models;
using Infrastructure.Memory.Repository;
using Web;

namespace WebAPI
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
            builder.Services.AddSingleton<IGenericRepository<Quiz, int>, MemoryGenericRepository<Quiz, int>>();
            builder.Services.AddSingleton<IGenericRepository<QuizItem, int>, MemoryGenericRepository<QuizItem, int>>();
            builder.Services.AddSingleton<IGenericRepository<QuizItemUserAnswer, string>, MemoryGenericRepository<QuizItemUserAnswer, string>>();
            builder.Services.AddSingleton<IQuizUserService, QuizUserService>();
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
            app.Seed();
            app.Run();
        }
    }
}