using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using pw3_proyecto.Entities;
using pw3_proyecto.Repositories;
using pw3_proyecto.Repositories.Interfaces;
using pw3_proyecto.Services;
using pw3_proyecto.Services.Interfaces;
using System;

namespace pw3_proyecto
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
            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            services.AddDbContext<_20212C_TPContext>(options => options.UseLazyLoadingProxies()
                                                                       .UseSqlServer(Configuration.GetConnectionString("EFCoreContext")));

            services.AddTransient<_20212C_TPContext>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITipoRecetaRepository, TipoRecetaRepository>();
            services.AddScoped<ITipoRecetaService, TipoRecetaService>();
            services.AddScoped<IRecetaRepository, RecetaRepository>();
            services.AddScoped<IRecetaService, RecetaService>();
            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<IEventoService, EventoService>();
            services.AddScoped<IEventoRepository, EventoRepository>();
            services.AddScoped<IReservaService, ReservaService>();
            services.AddScoped<IReservaRepository, ReservaRepository>();

            services.AddSession(options =>
            {
                options.Cookie.Name = ".MiAPP.Session";
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });

            services.AddRouting(options => options.LowercaseUrls = true);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}
			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
			{
                endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
