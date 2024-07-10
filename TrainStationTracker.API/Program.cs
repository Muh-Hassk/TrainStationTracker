using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
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
            builder.Services.AddScoped<ILoginRepository,LoginRepository>();
            builder.Services.AddScoped<ILoginService, LoginService>();
            builder.Services.AddScoped<IStatisticsRepository, StatisticsRepository>();
            builder.Services.AddScoped<IStatisticsService,  StatisticsService>();


            builder.Services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x => x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,// H,P, Sig => H, P + secret
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Albaraa Salman Alshehry, Mohammad Hassan ALkuzaea , Amzan Abdullah Aldowagri")),
                ClockSkew = TimeSpan.Zero
            }); ;

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
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
