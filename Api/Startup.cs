﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data;
using Api.Helpers;
using Api.Repos.Auth;
using Api.Repos.Fotos;
using Api.Repos.Values;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<DatingAppDbContext>(x => x.UseNpgsql(
                Configuration.GetConnectionString("DatingAppDb")));
            services.AddScoped<IValuesRepo, ValuesRepo>();
            services.AddScoped<IAuthRepo, AuthRepo>();
            services.AddScoped<IFotosRepo, FotosRepo>();
            services.AddCors();
            services.Configure<CloudinaryCreds>(Configuration.
                GetSection("Cloudinary")); /* Map JSON To Helper Class */
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).
                AddJwtBearer(x => x.TokenValidationParameters = new TokenValidationParameters{
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.
                        GetBytes(Configuration.GetSection("Key:Token").Value)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                
            }
            app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
