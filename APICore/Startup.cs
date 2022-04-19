using System;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using APICore.EmailService;
using APICore.ModelService;
using APICore.TokenService;
using APICore.DataService;
using APICore.GoogleService;
using Stripe;
using APICore.Repository;
using APICore.DataInterfaces;
using APICore.DataModelService;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace APICore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            StripeConfiguration.ApiKey = Configuration["StripeSettings:PrivateKey"];
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IJWtokenGenerator, JWtokenGenerator>();

            services.AddTransient<IEmailSvc, EmailSvc>();

            services.AddTransient<IGoogleJwtValidator, GoogleJwtValidator>();

            services.AddTransient<ISubscriptionRepository, SubscriptionRepository>();

            services.AddTransient<ICourseRepository, CourseRepository>();

            services.AddTransient<ICartRepository, CartRepository>();

            services.AddTransient<IAppUserRepository, AppUserRepository>();


            //services.AddRazorPages();
            services.AddHttpContextAccessor();

            services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.Configure<GoogleAuthSettings>(Configuration.GetSection("GoogleAuthSettings"));
            services.Configure<StripeSettings>(Configuration.GetSection("StripeSettings"));


            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseMySql(Configuration["ConnectionString:DBInfo"], new MySqlServerVersion(new Version(8, 0, 11)), b => b.MigrationsAssembly("APICore"));
            });

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 8;
                options.User.RequireUniqueEmail = true;
                //options.SignIn.RequireConfirmedEmail = true;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();


            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(opt =>
            {
                opt.RequireHttpsMetadata = false;
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["AppSettings:Key"])),
                    ValidIssuer = Configuration["AppSettings:Issuer"],
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };
            });


            services.AddAuthorization(options =>
            {
                options.AddPolicy("ManagerDevelopers", mg =>
                {
                    mg.RequireClaim("Jobtitle", "Developer");
                    mg.RequireRole("Manager");
                });

                options.AddPolicy("AdminDevelopers", ad =>
                {
                    ad.RequireClaim("Jobtitle", "Developer");
                    ad.RequireRole("Administrator");
                });
            });

            services.AddAntiforgery(options =>
            {
                options.HeaderName = "X-XSRF-TOKEN";
            });

            services.AddControllers();

            services.AddCors(options =>
            {
                options.AddPolicy("EnableCors", config =>
                {
                    config.AllowAnyOrigin();
                    config.AllowAnyHeader();
                    config.AllowAnyMethod();
                });
            });

            services.AddAutoMapper(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IAntiforgery antiforgery)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("EnableCors");

            app.UseAuthentication();

            app.UseAuthorization();

            app.Use(nextDelegate => context =>
            {
                string path = context.Request.Path.Value.ToLower();
                string[] directUrls = { "/api/appuser/users", "/api/appuser/users/{id}", "/api/appuser/users/firstname-update/{id}", "/api/appuser/users/lastname-update/{id}", "/api/appuser/users/username-update/{id}", "/api/appuser/users/email-update/{id}", "/api/appuser/delete/{id}", "/api/cartstore/cart", "/api/cartstore/addtoCart", "/api/cartstore/removeFromCart/{id}", "/api/external/externalLogger", "/api/loginuser/login", "/api/multipleitempayment/create-checkout-session", "/api/portal/customer-portal", "/api/product/items/products", "/api/product/getById/{id}", "/api/registeruser/register", "/api/security/forgotpassword", "/api/security/resetpassword", "/api/security/confirmemail", "/api/singleitempayment/create-checkout-session" };
                if (directUrls.Any(url => path.StartsWith(url)))
                {
                    AntiforgeryTokenSet tokens = antiforgery.GetAndStoreTokens(context);
                    context.Response.Cookies.Append("XSRF-TOKEN", tokens.RequestToken, new CookieOptions()
                    {
                        HttpOnly = false,
                        Secure = false,
                        IsEssential = true,
                        SameSite = SameSiteMode.Strict
                    });

                }

                return nextDelegate(context);
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
