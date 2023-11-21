
using CQRSWithMediatR.Context;
using CQRSWithMediatR.ServicesDependencies;
using Microsoft.EntityFrameworkCore;

namespace CQRSWithMediatR;

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

        #region DbContext
        builder.Services.AddDbContext<ApplicationDbContext>(opt =>
           opt.UseSqlServer(builder.Configuration.GetConnectionString("CompanyDb"))
        );

        #endregion

        #region Services
        builder.Services
            .AddRepositoriesDependencies()
            .AddUnitOfWrokDependencies()
            .AddServciesDependencies()
            .AddMeidatrDependencies();
        #endregion
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
