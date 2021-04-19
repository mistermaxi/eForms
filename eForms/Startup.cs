using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using eForms.Services.AutoMapper;
using eForms.Services.Interfaces;
using eForms.Services.Services;
using eForms.Services.Permissions;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using eForms.Domain.Context;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
//using eForms.Services.Options;
//using eForms.Services.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Server.HttpSys;
using Microsoft.AspNetCore.Server.IISIntegration;

namespace eForms
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
            // Added by ISC
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);//We set Time here 
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        //builder.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost");
                        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
                    });
            });

            services.AddSingleton(provider => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            }).CreateMapper());

            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

            services.AddDbContext<eFormsContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("eFormsConn")));


            services.AddTransient<IeFormsContext, eFormsContext>();
            services.AddTransient<ISanitizationService, SanitizationService>();

            /////////////////////////////
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IProfileService, ProfileService>();
            /////////////////////////////
            services.AddTransient<IUploadService, UploadService>();

            /////////////////////////////
            services.AddTransient<IBuildingService, BuildingService>();
            services.AddTransient<ICountryService, CountryService>();
            services.AddTransient<IEmpTypeService, EmpTypeService>();
            services.AddTransient<IFormService, FormService>();
            services.AddTransient<IIPCService, IPCService>();
            services.AddTransient<IISOService, ISOService>();
            services.AddTransient<IISSOService, ISSOService>();
            services.AddTransient<ILanguageService, LanguageService>();
            services.AddTransient<IMilitaryRankService, MilitaryRankService>();
            services.AddTransient<IPostService, PostService>();
            services.AddTransient<IPrefixService, PrefixService>();
            services.AddTransient<IRelationshipService, RelationshipService>();
            services.AddTransient<ISectionService, SectionService>();
            services.AddTransient<IStatesService, StatesService>();

            /////////////////////////////
            


            services.AddAuthorization();
            //services.AddAuthentication(IISDefaults.AuthenticationScheme); 
            //services.AddAuthorization();

            // IISDefaults requires the following import:
            // using Microsoft.AspNetCore.Server.IISIntegration;
            //services.AddAuthentication(IISDefaults.AuthenticationScheme);

            // HttpSysDefaults requires the following import:
            // using Microsoft.AspNetCore.Server.HttpSys;
            //services.AddAuthentication(HttpSysDefaults.AuthenticationScheme);


            services.AddControllersWithViews();
            services.AddRazorPages().AddRazorRuntimeCompilation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSession();
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var _context = serviceScope.ServiceProvider.GetRequiredService<eFormsContext>();
                _context.Database.EnsureCreated();
            }
            //UpdateDatabase(app);

            app.UseCors();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });

        }
        //private void UpdateDatabase(IApplicationBuilder app)
        //{
        //    using (IServiceScope serviceScope = app.ApplicationServices
        //        .GetRequiredService<IServiceScopeFactory>()
        //        .CreateScope())
        //    {
        //        using (eFormsContext context = serviceScope.ServiceProvider.GetService<eFormsContext>())
        //        {
        //            context.Database.Migrate();
        //        }
        //    }
        //}
    }
}
