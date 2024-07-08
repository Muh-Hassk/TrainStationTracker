using TrainStationTracker.core.ICommon;
using TrainStationTracker.core.IRepository;
using TrainStationTracker.core.IService;
using TrainStationTracker.infra.Common;
using TrainStationTracker.infra.Repository;
using TrainStationTracker.infra.Service;

namespace TrainStationTracker.API
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
            builder.Services.AddScoped<IDbContext, Dbcontext>();
            builder.Services.AddScoped<ITrainStationRepository, TrainStationRepository>();
            builder.Services.AddScoped<ITrainStationService, TrainStationService>();
            var app = builder.Build();
            // Master Locally

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
