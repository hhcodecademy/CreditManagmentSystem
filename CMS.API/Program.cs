
using CMS.API.Validation;
using CMS.BLL.Mappers;
using CMS.BLL.Services;
using CMS.BLL.Services.Interface;
using CMS.DAL.Data;
using CMS.DAL.DTOS;
using CMS.DAL.Repository;
using CMS.DAL.Repository.Interface;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System.Reflection;

namespace CMS.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var logger = new LoggerConfiguration()
                .ReadFrom.Configuration(new ConfigurationBuilder()
                .AddJsonFile("seri-log.config.json")
                .Build())
                .Enrich.FromLogContext()
                .CreateLogger();
            builder.Logging.ClearProviders();
            builder.Logging.AddSerilog(logger);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<CMSContext>(opts =>
            {
                opts.UseSqlServer(builder.Configuration.GetConnectionString("SQLConnectionString"));
            });

            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            builder.Services.AddScoped(typeof(IGenericService<,>), typeof(GenericService<,>));

            builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(CustomProfile)));

            builder.Services.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining(typeof(BranchValidator)));
            ValidatorOptions.Global.LanguageManager.Culture = new System.Globalization.CultureInfo("az");


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
