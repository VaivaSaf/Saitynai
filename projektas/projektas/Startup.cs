using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using projektas.Data;
using projektas.Data.Repositories;
using projektas.Auth.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using projektas.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;

namespace projektas
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
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            services.AddSwaggerGen();
            services.AddRazorPages();
            services.AddControllers();
            // kaip userio entity vadinas? xd
            services.AddIdentity<ForumRestUser, IdentityRole>(o =>
            {
                o.Password.RequireDigit = false;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequiredLength = 6;
            })
                .AddEntityFrameworkStores<ForumDbContext>()
                .AddDefaultTokenProviders();

       

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters.ValidAudience = Configuration["JWT:ValidAudience"];
                options.TokenValidationParameters.ValidIssuer = Configuration["JWT:ValidIssuer"];
                options.TokenValidationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"]));
            }
            );
            services.AddDbContext<ForumDbContext>();

            services.AddTransient<IOffersRepository, OffersRepository>();
            services.AddTransient<IItemsRepository, ItemsRepository>();
            services.AddTransient<IAuctionsRepository, AuctionsRepository>();
            services.AddTransient<IJwtTokenService, JwtTokenService>();
            services.AddScoped<AuthDbSeeder>();
            services.AddControllers(options => options.SuppressAsyncSuffixInActionNames = false);

            services.AddAuthorization(options =>
            {
                options.AddPolicy(PolicyNames.ResourceOwner, policy => policy.Requirements.Add(new ResourceOwnerRequirement()));
            });

            services.AddSingleton<IAuthorizationHandler, ResourceOwnerAuthorizationHandler>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public async void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


            using var scope = app.ApplicationServices.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<ForumDbContext>();
            dbContext.Database.Migrate();

            var dbSeeder = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<AuthDbSeeder>();
            await dbSeeder.SeedAsync();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });

            app.UseSwagger();
            app.UseSwaggerUI();
        }
    }
}
