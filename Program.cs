
using Microsoft.EntityFrameworkCore;
using CollegeInfoSystem.Context;
using CollegeInfoSystem.Helper;
using CollegeInfoSystem.Repository;
using Microsoft.OpenApi.Models;
using System.Reflection;
using CollegeInfoSystem.Models;

namespace CollegeInfoSystem
{
    public class Program
    {

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<MyContext>(options=>
            options
            .UseSqlServer(builder.Configuration.GetConnectionString("ConnStr")));

            //Dependency Injection 
           
            builder.Services.AddScoped<ICollege,CollegeRepo>();
            builder.Services.Configure<Messages>(builder.Configuration.GetSection("Messages"));
            
            
           



            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(
            c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CollegeInfoSystem", Version = "V1" });
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
                c.CustomSchemaIds(x => x.FullName);
            });

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