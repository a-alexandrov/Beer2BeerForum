using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Linq;
using System.Reflection;
using Beer2Beer.Data.Contracts;
using Beer2Beer.Data;
using AutoMapper;
using QuizOverflow.Services.MappingProfiles;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Beer2Beer.Web.Utility;

namespace Beer2Beer.Web
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
            //register ExceptionFilter
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(GlobalExceptionFilters));
            });

            //register Newtonsoft JSON serialiser, Stopping EF REfferenceLoops.
            services.AddControllers().AddNewtonsoftJson(
                    options => options.SerializerSettings.ReferenceLoopHandling
                    = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v2", new OpenApiInfo { Title = "Beer2BeerAPI", Version = "v2" });
            });

            services.AddControllersWithViews();

            //Automapper 
            AutoMapper.IConfigurationProvider config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            services.AddSingleton(config);
            services.AddScoped<IMapper, Mapper>();

            services.AddScoped<IBeer2BeerDbContext, Beer2BeerDbContext>();

            //register servises using reflection.
            this.RegisterServices(services);

            // register authentication

            // In this example, we have specified which parameters must be taken into account to consider JWT as valid. As per our code,  the following items consider a token valid:
            // Validate the server(ValidateIssuer = true) that generates the token.
            // Validate the recipient of the token is authorized to receive(ValidateAudience = true)
            // Check if the token is not expired and the signing key of the issuer is valid(ValidateLifetime = true)
            // Validate signature of the token(ValidateIssuerSigningKey = true)
            // Additionally, we specify the values for the issuer, audience, signing key.In this example, I have stored these values in appsettings.json file.
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["Jwt:Issuer"],
                        ValidAudience = Configuration["Jwt:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                    };
                });

            services.AddScoped<IAuthenticator, Authenticator>();
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v2/swagger.json", "Beer2BeerAPI");
            });

            app.UseAuthentication();
        }

        public void RegisterServices(IServiceCollection services)
        {
            var servicesToRegister = Assembly.Load("Beer2Beer.Services")
                                      .GetTypes()
                                      .Where(x => x.IsClass && x.Name.Contains("Service"))
                                      .Select(s => new
                                      {
                                          Interface = s.GetInterface($"I{s.Name}"),
                                          Implementation = s
                                      })
                                      .ToList();

            foreach (var type in servicesToRegister)
            {
                services.AddScoped(type.Interface, type.Implementation);
            }
        }
    }
}
