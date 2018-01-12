using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Cors;

namespace ClbcRestService
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
            services.AddCors();
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // the corsUrl must be specified without a trailing slash. 
            // See: https://docs.microsoft.com/en-us/aspnet/core/security/cors
            const string corsUrl = "http://localhost:3000";
            app.UseCors(options => options.WithOrigins(corsUrl).AllowAnyMethod());

            app.UseMvc();
        }
    }
}
