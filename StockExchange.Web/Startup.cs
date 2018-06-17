using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using StockExchange.Data;

namespace StockExchange.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            SigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration["SecretKey"]));
        }

        public IConfiguration Configuration { get; }
        private SymmetricSecurityKey SigningKey { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<StockExchangeContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("StockExchange"),
              b => b.MigrationsAssembly("StockExchange.Data")));

            //services.AddSingleton<IJwtFactory, JwtFactory>();

            services.AddCors();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseCors(builder =>
                    builder.WithOrigins("http://localhost:4200")
                        .AllowAnyHeader()
                        .AllowAnyMethod());
            }

            //OAuthAuthorizationServerOptions option = new OAuthAuthorizationServerOptions
            //{
            //    TokenEndpointPath = new PathString("/token"),
            //    Provider = new ApplicationOAuthProvider(),
            //    AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(60),
            //    AllowInsecureHttp = true
            //};
            //app.UseOAuthAuthorizationServer(option);
            //app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());


            app.UseMvc();
        }
    }
}
