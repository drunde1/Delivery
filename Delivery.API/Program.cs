
using Delivery.Application.Services;
using Delivery.DataAccess;
using Delivery.DataAccess.Reposetories;
using Microsoft.EntityFrameworkCore;

namespace Delivery.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<DeliveryDbContext>(
               options =>
               {
                   options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(DeliveryDbContext)));
               });

            builder.Services.AddScoped<IOrdersFiltersReposetory, OrdersFiltersReposetory>();
            builder.Services.AddScoped<ILogReposetory, LogReposetory>();
            builder.Services.AddScoped<IOrdersService, OrdersService>();

            var app = builder.Build();

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
