using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddDbContext<Context>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"));
        });
        
        builder.Services.AddCors(options =>
        {
            options.AddPolicy(
                name: "origins",
                policy =>
                {
                    policy.WithOrigins("http://localhost:5173/");
                });
         });


        var app = builder.Build();

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.UseCors("origins");

        app.Run();
    }
}