using AutoMapper;
using FamousQuoteQuiz.API;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NaturalPersonReference.BL.Interfaces;
using NaturalPersonReference.DB;
using NaturalPersonReference.Factories;
using NaturalPersonReference.MapperProfiles;
using NaturalPersonReference.Middlewares;
using NaturalPersonReference.Models.Person;
using NaturalPersonReference.Services.localization;
using NaturalPersonReference.Services.Persons;
using NaturalPersonReference.Validators;

namespace NaturalPersonReference
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
            services.AddControllersWithViews().AddFluentValidation();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IPersonModelFactory, PersonModelFactory>();
            services.AddScoped<ICityModelFactory, CityModelFactory>();
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<ILocalizationService, LocalizationService>();
            services.AddAutoMapper(c => c.AddProfile<PersonProfile>(), typeof(Startup));
            services.AddTransient<IValidator<PersonModel>, PersonValidator>();
            services.AddTransient<IValidator<PhoneModel>, PhoneValidator>();

            IConfigurationSection appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);
            AppSettings appSettings = appSettingsSection.Get<AppSettings>();

            var connection = $"Server=tcp:{appSettings.SqlServerHostName},{appSettings.SqlServerPost};Initial Catalog={appSettings.SqlServerCatalog};Persist Security Info=False;User ID={appSettings.SqlServerUser};Password={appSettings.SqlServerPassword};MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False;Connection Timeout=30;";

            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(connection);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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

            app.UseMiddleware<ErrorLoggerMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=person}/{action=create}/{id?}");
            });
        }
    }
}
