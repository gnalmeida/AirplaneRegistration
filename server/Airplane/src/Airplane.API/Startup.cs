using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.AspNetCore.Http;
using Airplane.IOC;
using Airplane.API.Extensions;
using Airplane.Bus;

namespace Airplane.API
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
			services.AddAutoMapperSetup();

			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

			services.AddSwaggerGen(s =>
			{
				s.SwaggerDoc("v1", new Info
				{
					Version = "v1",
					Title = "Airplane API",
					Description = "API Airplane",
					TermsOfService = "Nenhum"
				});
			});

			services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
			{
				builder.AllowAnyOrigin()
					   .AllowAnyMethod()
					   .AllowAnyHeader();
			}));
			RegisterServices(services);
		}

		public void Configure(IApplicationBuilder app, IHostingEnvironment env, IHttpContextAccessor accessor)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseMvc();

			app.UseSwagger();
			app.UseSwaggerUI(s =>
			{
				s.SwaggerEndpoint("/swagger/v1/swagger.json", "Airplane API v1.0");
			});

			app.UseCors("MyPolicy");
			
			InMemoryBus.ContainerAccessor = () => accessor.HttpContext.RequestServices;
		}

		private static void RegisterServices(IServiceCollection services)
		{
			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

			NativeInjectorBootStrapper.RegisterServices(services);
		}
	}
}
