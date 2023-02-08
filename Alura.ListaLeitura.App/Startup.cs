using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Alura.ListaLeitura.App
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {           
            services.AddMvcCore();
        }
        public void Configure(IApplicationBuilder app)
        {       
            app.UseMvcWithDefaultRoute();
        }     
    }
}