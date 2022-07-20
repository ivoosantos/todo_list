using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todo_list.DataAccess;
using todo_list.Repositories;

namespace todo_list
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
            services.AddSwaggerGen(cfg =>
            {
                cfg.ResolveConflictingActions(apiDescription => apiDescription.First());
                cfg.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "API", Version = "v1" });
                
            });


            services.AddControllers();
            var connectionPostgre = Configuration["ConnectionStrings:DBIEQSYSTEMPOSTGRE"];
            services.AddDbContext<DataContext>(options => options.UseNpgsql(connectionPostgre));

            services.AddScoped<ITodoRepository, TodoRepository>();
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseRouting();

            app.UseAuthorization();
            app.UseSwagger();

            app.UseSwaggerUI(cfg => {
                cfg.SwaggerEndpoint("/swagger/v1/swagger.json", "Todo");
                cfg.RoutePrefix = String.Empty;
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
