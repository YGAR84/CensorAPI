using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CorrectAPI.ObsceneWordProvider;
using CorrectAPI.StringChecker;

namespace CorrectAPI
{
	public class Startup
	{
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddSingleton<IObsceneWordProvider, DefaultObsceneWordProvider>();
			services.AddScoped<ObsceneStringChecker>();
			services.AddControllers();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseRouting();
			

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});

	
		}
	}
}
