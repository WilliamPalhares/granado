using AutoMapper;
using granado_clinica_veterinaria_api.Configurations;
using granado_clinica_veterinaria_business.Interfaces;
using granado_clinica_veterinaria_business.Profiles;
using granado_clinica_veterinaria_business.Repositories;
using granado_clinica_veterinaria_business.Services;
using granado_clinica_veterinaria_domain.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO.Compression;

namespace granado_clinica_veterinaria_api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        readonly string MyAllowSpecificOrigins = "AllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }       

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //Adicionando o AutoMapper
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ClinicaProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            //Criando a Singleton do arquivo de configurações
            ConfigurationApplication application = Configuration.GetSection("ConfigurationApplication").Get<ConfigurationApplication>();
            services.AddSingleton(application);

            //Adicionando o servico de cache na aplicacao
            services.AddDistributedMemoryCache();

            services.AddMvc();

            //Configurando a compressão de dados
            services.Configure<GzipCompressionProviderOptions>(op => op.Level = CompressionLevel.Optimal);

            services.AddResponseCompression(op =>
            {
                op.Providers.Add<GzipCompressionProvider>();
            });

            //Configurando o Swagger da Aplicação
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Api Clinica Veterinaria Granado",
                    Description = "Api de suporte ao Site Clinica Veterinaria Granado",
                    Contact = new OpenApiContact
                    {
                        Name = "William Palhares",
                        Email = "williampalharesrj@gmail.com",
                        Url = new Uri("https://www.linkedin.com/in/william-palhares-34818625/"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under LICX",
                    }
                });
            });

            //Configurando o Cors da aplicação
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.WithOrigins("http://localhost:4200", "*", "*")
                           .WithHeaders()
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
            });

            //Configurando o banco de dados da aplicação
            services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(application.ConnectionString));

            //Injeção de Dependência Repository
            services.AddTransient<IAgendamentoRepository, AgendamentoRepository>();
            services.AddTransient<IAnimalRepository, AnimalRepository>();
            services.AddTransient<IAtendimentoRepository, AtendimentoRepository>();
            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddTransient<ITipoAnimalRepository, TipoAnimalRepository>();
            services.AddTransient<IVeterinarioRepository, VeterinarioRepository>();

            //Injeção de Dependência Services
            services.AddTransient<AgendamentoService, AgendamentoService>();
            services.AddTransient<AnimalService, AnimalService>();
            services.AddTransient<AtendimentoService, AtendimentoService>();
            services.AddTransient<ClienteService, ClienteService>();
            services.AddTransient<TipoAnimalService, TipoAnimalService>();
            services.AddTransient<VeterinarioService, VeterinarioService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Habilitando o Cors
            app.UseCors(MyAllowSpecificOrigins);

            //Habilitando o Swagger para API da Clinica
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
            });

            //Habilitando a Compressão de dados
            app.UseResponseCompression();

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
