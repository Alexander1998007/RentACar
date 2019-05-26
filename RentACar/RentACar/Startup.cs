using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using RentACar.BLL.Interfaces;
using RentACar.BLL.Services;
using RentACar.BLL.Mappers;
using RentACar.DAL.EF;
using RentACar.DAL.Entities;
using RentACar.DAL.Interfaces;
using RentACar.DAL.Repositories;

namespace RentACar
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<RentACarContext>(options =>
                  options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<RentACarContext>()
                .AddDefaultTokenProviders();

            // Identity options
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 8;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;

                // Lockout settings
                options.Lockout.MaxFailedAccessAttempts = 3;

                // User settings
                options.User.RequireUniqueEmail = true;

                // Signin settings
                //options.SignIn.RequireConfirmedEmail = true;
            });

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();

            // Repositories
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<IRentalRepository, RentalRepository>();

            // Services
            services.AddScoped<IApplicationUserService, ApplicationUserService>();
            services.AddScoped<ICarService, CarService>();
            services.AddScoped<IRentalService, RentalService>();

            // Mappers
            services.AddSingleton(Mapper.Initialize());

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
