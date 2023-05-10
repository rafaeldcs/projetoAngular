using apiTestes.Data;
using apiTestes.Repositorios.Interfaces;
using apiTestes.Repositorios;
using Microsoft.EntityFrameworkCore;
using apiFuncional.Repositorios;
using System.Text.Json.Serialization;
using System.Text.Json;
using apiTestes.Models;
using Newtonsoft.Json;
using static Org.BouncyCastle.Math.EC.ECCurve;
using Microsoft.AspNetCore.Http.Json;

namespace apiFuncional
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var myAllowSpecificOrigens = "_myAllowSpecificOrigens";
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services
                .AddDbContext<SistemaDadosDB>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("Database"))
                );

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: myAllowSpecificOrigens, 
                    builder => 
                    {
                            builder.WithOrigins("http://localhost:4200")
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                   }); 
            });

            builder.Services.AddScoped<IPessoaService, PessoaService>();
            builder.Services.AddScoped<IPessoaRepository, PessoaRepository>();
            builder.Services.AddScoped<IContatoService, ContatoService>();
            builder.Services.AddScoped<IContatoRepository, ContatoRepository>();



            var app = builder.Build();


          
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

      

            app.UseHttpsRedirection();

            app.UseCors(myAllowSpecificOrigens);

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
