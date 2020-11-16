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
using NaturalPersonReference.ActionFilters;
using NaturalPersonReference.BL.Interfaces;
using NaturalPersonReference.DB;
using NaturalPersonReference.DB.Implementations;
using NaturalPersonReference.Factories;
using NaturalPersonReference.MapperProfiles;
using NaturalPersonReference.Middlewares;
using NaturalPersonReference.Models.Person;
using NaturalPersonReference.Services.localization;
using NaturalPersonReference.Services.Persons;
using NaturalPersonReference.Services.Report;
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
            services.AddControllersWithViews(opt=>opt.Filters.Add(typeof(PersonActionFilter))).AddFluentValidation();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IPersonModelFactory, PersonModelFactory>();
            services.AddScoped<ICityModelFactory, CityModelFactory>();
            services.AddScoped<IPersonService, PersonService>();
            services.AddAutoMapper(c => c.AddProfile<PersonProfile>(), typeof(Startup));
            services.AddTransient<IValidator<PersonModel>, PersonValidator>();
            services.AddTransient<IValidator<PhoneModel>, PhoneValidator>();
            services.AddScoped<ILocalizationService, LocalizationService>();
            services.AddScoped<IPictureModelFactory, PictureModelFactory>();
            services.AddScoped<IReportService, ReportService>();

            IConfigurationSection appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);
            AppSettings appSettings = appSettingsSection.Get<AppSettings>();

            services.AddSingleton<IWorkContext>(wk=> new WorkContext { LanguangeId = appSettings.LanguageId});

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
                    pattern: "{controller=person}/{action=list}/{id?}");
            });
        }
    }
}
