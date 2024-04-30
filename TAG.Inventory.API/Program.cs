
using Microsoft.EntityFrameworkCore;
using TAG.Inventory.Entities;
using TAG.Inventory.Repository;
using TAG.Inventory.Repository.Implementation;
using TAG.Inventory.Repository.Interface;
using static System.Net.Mime.MediaTypeNames;

namespace TAG.Inventory.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            //Add ApplicationDbContext
            builder.Services.AddDbContext<ApplicationDbContext>(
                options=>options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("TAG.Inventory.API")));

            //Add Generic repo
            builder.Services.AddScoped(typeof(IRepository<Product>), typeof(GenericRepository));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

            app.Run();
        }
    }
}
