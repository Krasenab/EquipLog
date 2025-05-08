using EquipLog.Data.SQL.Models;
using EquipLogData;
using EquipLog.Web.Infrastructure;


using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

using MongoDB.Driver;
using EquipLog.Services;
using EquipLog.Interfaces;

namespace EquipLog
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<EquipLogDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<ApplicationUser>(options => 
            {
                options.SignIn.RequireConfirmedAccount = builder.Configuration.GetValue<bool>("Identity:SignIn:RequiredConfirmedAccount");
                options.Password.RequireLowercase = builder.Configuration.GetValue<bool>("Identity:Password:RequireLowercase");
                options.Password.RequireUppercase = builder.Configuration.GetValue<bool>("Identity:Password:RequireUppercase");
                options.Password.RequireNonAlphanumeric = builder.Configuration.GetValue<bool>("Identity:Password:RequireNonAlphanumeric");
                options.Password.RequireDigit = builder.Configuration.GetValue<bool>("Identity:Password:RequireDigit");
            })
                .AddRoles<IdentityRole<Guid>>()
                .AddEntityFrameworkStores<EquipLogDbContext>();

            // Add services with method
            builder.Services.AddAppServices(typeof(EquipmentService));
            builder.Services.ConfigureApplicationCookie(cfg => 
            {
                cfg.LogoutPath = "/AppUser/Login";
            });

            //Configure MongoDB Atlas 
            builder.Services.Configure<EquipLogMongoDbSettings>(
                builder.Configuration.GetSection("MongoDbSettings")
                );
            builder.Services.AddSingleton<IMongoClient>(m =>  {
                var config = m.GetRequiredService<IOptions<EquipLogMongoDbSettings>>().Value;
                return new MongoClient(config.ConnectionString);
            });
            builder.Services.AddSingleton(sp =>
            {
                var config = sp.GetRequiredService<IOptions<EquipLogMongoDbSettings>>().Value;
                var client = sp.GetRequiredService<IMongoClient>();
                return client.GetDatabase(config.DatabaseName);
            });

            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();
            //app.MapGet("/mongo-test", async (IMongoDatabase db) =>
            //{
            //    var names = await db.ListCollectionNames().ToListAsync();
            //    return Results.Ok(new { Collections = names });
            //});


            app.Run();
        }
    }
}
