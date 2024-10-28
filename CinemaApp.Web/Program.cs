using Microsoft.EntityFrameworkCore;
namespace CinemaApp.Web
{
    using CinemaApp.Data.Models;
    using CinemaApp.Data.Repository;
    using CinemaApp.Data.Repository.Interfaces;
    using CinemaApp.Services.Data;
    using CinemaApp.Services.Data.Interfaces;
    using CinemaApp.Services.Mapping;
    using CinemaApp.Web.Infrastructure.Extensions;
    using CinemaApp.Web.ViewModels;
    using Data;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using NuGet.Protocol.Core.Types;

    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            string? connectionString = builder.Configuration.GetConnectionString("SQLServer");
            // Add services to the container.
            builder.Services.AddDbContext<CinemaDbContext>(options => {
                options.UseSqlServer(connectionString); 
            });

            /// TUKA DA SE KONFIGURIRRA ZA IDENTITY SU^TO!!!!!!!!!!!!!!!
            builder.Services.AddIdentity<ApplicationUser, IdentityRole<Guid>>(options =>
            {
                ConfigureIdentity(options, builder);
                options.Lockout.MaxFailedAccessAttempts = 5;    
            })
                .AddEntityFrameworkStores<CinemaDbContext>()          //// ADD ALL THIS THINGS
                .AddRoles<IdentityRole<Guid>>()
                .AddSignInManager<SignInManager<ApplicationUser>>()
                .AddUserManager<UserManager<ApplicationUser>>();

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Identity/Account/Login";
            });

            builder.Services.AddScoped<IRepository<Movie, Guid>, BaseRepository<Movie, Guid>>();
            builder.Services.AddScoped<IRepository<Cinema, Guid>, BaseRepository<Cinema, Guid>>();
            builder.Services.AddScoped<IRepository<CinemaMovie, object>, BaseRepository<CinemaMovie, object>>();
            builder.Services.AddScoped<IRepository<ApplicationUserMovie, object>, BaseRepository<ApplicationUserMovie, object>>();

            // we have to register the service into the IServiceCollection
            builder.Services.AddScoped<ICinemaService, CinemaService>();

            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();                     //// ADD RAZOR PAGES


            WebApplication app = builder.Build();

            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).Assembly);

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
                                                                    /// TUKA SE DOBAVIA ADD AUTHENTICATION!!!!!!!!!!!!!!!
            app.UseAuthentication();    // who am I?
            app.UseAuthorization();     // what can I do?

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
                                            ////tuka se mapvat razor pages, toest se praviat routing tables for razor pages !!!!!!!!!!!!!!!!!!!
            app.MapRazorPages();                                                           
            
            app.ApplyMigrations();  /// it will APPLY all migrations at start up. 
            app.Run();
        }


          /// <summary>
         ///   Da ne se trupa gore go iznesohme v otdelen method
        /// </summary>
        private static void ConfigureIdentity(IdentityOptions options, WebApplicationBuilder builder)
        {
            options.Password.RequireDigit
                             = builder.Configuration.GetValue<bool>("Idetity:Password:RequredDigits");
            options.Password.RequireLowercase
                         = builder.Configuration.GetValue<bool>("Identity:Password:RequireLowerCase");
            options.Password.RequireNonAlphanumeric
                         = builder.Configuration.GetValue<bool>("Identity:Password:RequireNonAlphaNumerical");
            options.Password.RequiredLength
                         = builder.Configuration.GetValue<int>("Identity:Password:RequiredLength");
            options.Lockout.DefaultLockoutTimeSpan
                         = builder.Configuration.GetValue<TimeSpan>("Identity:LockOut:DefaultLockoutTimeSpan");
        }


    }
}
