using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebApiSistema_PrimeraEntrega_GuidoComba.database;
using WebApiSistema_PrimeraEntrega_GuidoComba.Mapper;
using WebApiSistema_PrimeraEntrega_GuidoComba.Service;


namespace WebApiSistema_PrimeraEntrega_GuidoComba
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

            builder.Services.AddDbContext<CoderContext>(options => { options.UseSqlServer("Server=.;Database=coderhouse; Trusted_Connection=True;"); });

            builder.Services.AddScoped<UsuarioData>();
            builder.Services.AddScoped<ProductoData>();
            builder.Services.AddScoped<ProductoVendidoData>();
            builder.Services.AddScoped<VentaData>();

            builder.Services.AddScoped<UsuarioMapper>();
            builder.Services.AddScoped<ProductoMapper>();
            builder.Services.AddScoped<ProductoVendidoMapper>();
            builder.Services.AddScoped<VentaMapper>();

            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy => {
                    policy.AllowAnyMethod();
                    policy.AllowAnyOrigin();
                    policy.AllowAnyHeader();
                
                });
            });

            var app = builder.Build();


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors();
            
            app.UseHttpsRedirection();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
