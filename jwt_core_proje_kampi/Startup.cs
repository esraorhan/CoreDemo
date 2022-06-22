using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jwt_core_proje_kampi
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "jwt_core_proje_kampi", Version = "v1" });
            });

            //jwt i�in gereklli konfigrasyon i�lemleri
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;  //htttp dahil edilmedi�inden gerek medi�ini belirtmemiz gereken yer 
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = "http://localhost", //�al�saca��n alan 
                    ValidAudience = "http://localhost", //kullan�lacak taraf
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("aspnetcreprojekampi")), //Token anahtar kodu olacak .
                    ValidateIssuerSigningKey = true, //token ��z�mlenemesi i�n 
                    ValidateLifetime=true,//zaman fark� ol�mas�n
                    ClockSkew=TimeSpan.Zero
                };
            }); //jwt konfigirasyon yap�lan yer
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "jwt_core_proje_kampi v1"));
            }

            app.UseRouting();
            app.UseAuthentication(); // [Authorize] sayfa 1 de eri�im sa�lanmas�  bunu eklememiz gerekti.
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
