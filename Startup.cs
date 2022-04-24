using APIMuhasibat.Data;
using APIMuhasibat.Models;
using APIMuhasibat.Models.LOGER;
using APIMuhasibat.Models.ViewModels;
using APIMuhasibat.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace APIMuhasibat
{
    class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
             Configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<ApplicationDbContext>(ServiceLifetime.Transient);
            services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
            })
             .AddEntityFrameworkStores<ApplicationDbContext>()
             .AddDefaultTokenProviders();
            services.AddControllers();
            //--------------------Jwt-------------------------------
            var key = Encoding.ASCII.GetBytes(Configuration["Jwt:Key"]);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                   // ClockSkew = TimeSpan.Zero
                    ClockSkew = TimeSpan.FromMinutes(30)//Zero
                };
            });
            //---------------------global cors policy----------------------
            var clientDomain = Configuration.GetValue<string>("ClientDomain");
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins(clientDomain)
                                      .AllowAnyHeader()
                                      .AllowAnyMethod()
                                      .AllowAnyOrigin()
                                      .AllowAnyMethod();
                                  });
            });

           
            //json serialize
            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft
                .Json.ReferenceLoopHandling.Ignore)
                .AddNewtonsoftJson(o => o.SerializerSettings.ContractResolver =
                new DefaultContractResolver());

            //----------------Service-----------------
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "APIMuhasibat", Version = "v1" });
            });
        }
        readonly string MyAllowSpecificOrigins = "ClientDomain";
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void WhateverController(IHttpContextAccessor context) //In the constructor
        {
            var request = context.HttpContext.Request;
            var _baseURL = $"{request.Scheme}://{request.Host}"; // http://localhost:5000
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ApplicationDbContext context,
            RoleManager<ApplicationRole> roleManager, UserManager<ApplicationUser> userManager, ILoggerFactory loggerFactory)
        {

            // string url = HttpContext.Current.Request.Url.AbsoluteUri;
           
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "APIMuhasibat v1"));
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            //------------------- global cors policy---------------
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors(MyAllowSpecificOrigins);

            //--------------------------------------
            var supportedCultures = new[] { new CultureInfo("en-US") };
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("en-US"),
                // Formatting numbers, dates, etc.
                SupportedCultures = supportedCultures,
                // UI strings that we have localized.
                SupportedUICultures = supportedCultures
            });
            //---------------file-uplode------------------
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Uploade")),
                RequestPath = new PathString("/Uploade")
            });
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Images")),
                RequestPath = new PathString("/Images")
            });
            //--------------------------------------------
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            loggerFactory.AddFile(Path.Combine(Directory.GetCurrentDirectory(), "logger.txt"));
            var logger = loggerFactory.CreateLogger("FileLogger");

            app.Run(async (context) =>
            {
                logger.LogInformation("Processing request {0}", context.Request.Path);
                await context.Response.WriteAsync("Hello World!");
            });
            DummyData.Initialize(context, userManager, roleManager).Wait();
        }
    }
}
