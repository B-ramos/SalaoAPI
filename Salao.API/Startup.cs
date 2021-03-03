using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Salao.Data.Context;
using Salao.Data.Repository;
using Salao.Data.Repository.Implementations;
using Salao.Data.Repository.Interface;
using Salao.Data.Services;
using Salao.Data.Services.Implementations;

namespace Salao.API
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
            services.AddDbContext<SalaoContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("SQLConnection")));

            services.AddControllers()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            

            //Dependency Injection Services
            services.AddScoped<IAgendamentoService, AgendamentoService>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IEnderecoService, EnderecoService>();
            services.AddScoped<IFuncionarioService, FuncionarioService>();
            services.AddScoped<IFuncionarioServicoService, FuncionarioServicoService>();
            services.AddScoped<IServicoService, ServicoService>();

            //Dependency Injection Repository
            services.AddScoped<IAgendamentoRepository, AgendamentoRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
            services.AddScoped<IFuncionarioServicoRepository, FuncionarioServicoRepository>();
            services.AddScoped<IServicoRepository, ServicoRepository>();
        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
