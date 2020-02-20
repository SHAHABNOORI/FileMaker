using FileMaker.Dal.Repositories.Implements;
using FileMaker.Dal.Repositories.Interfaces;
using FileMaker.Dal.UnitOfWork.Implements;
using FileMaker.Dal.UnitOfWork.Interfaces;
using FileMaker.Domain.Contexts;
using FileMaker.Service.Implements.Modules.Clients;
using FileMaker.Service.Implements.Modules.Languages;
using FileMaker.Service.Implements.Modules.Origins;
using FileMaker.Service.Interfaces.Modules.Clients;
using FileMaker.Service.Interfaces.Modules.Languages;
using FileMaker.Service.Interfaces.Modules.Origins;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace FileMaker.Api
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
            services.AddDbContext<FileMakerFinalContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<IClientRepository, ClientRepository>();
            services.AddTransient<ILanguagesService, LanguagesService>();
            services.AddTransient<IOriginsService, OriginsService>();
            services.AddTransient<IClientServices,ClientServices>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FileMaker Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "FileMaker Api V1"); });
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
