using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Salao.Data.Context;
using Salao.Data.Repository.Implementations;
using Salao.Data.Repository.Interface;
using Salao.Data.Services.Implementations;
using Salao.Data.Services.Interface;
using System;
using System.IO;
using System.Reflection;

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


            //Config Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API Salao ",
                    Description = "Serviço para salão de beleza",
                    TermsOfService = new Uri("https://go.microsoft.com/fwlink/?LinkID=206977"),
                    Contact = new OpenApiContact
                    {
                        Name = "Your name",
                        Email = string.Empty,
                        Url = new Uri("https://www.microsoft.com/learn")
                    }
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint("/swagger/v1/swagger.json", "Salao API CampinasTech");
            });

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
