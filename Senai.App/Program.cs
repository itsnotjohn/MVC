using AutoMapper;
using Senai.Domain.Interfaces;
using Senai.Repository.Context;
using Senai.Repository.Repositories;
using Senai.Service.Interfaces;
using Senai.Service.Services;

namespace Senai.App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<SenaiContext>();

            #region Injeção Services

            builder.Services.AddScoped<IEscolaService, EscolaService>();

            // Usou a aplicacao, depois ele derruba
            //builder.Services.AddTransient<>();

            //fica para sempre a aplicacao erguida
            //builder.Services.AddSingleton<>();

            #endregion

            #region Injeção Repositórios

            builder.Services.AddScoped<IEscolaRepository, EscolaRepository>();
            builder.Services.AddScoped<IEstadoService, EstadoService>();

            #endregion

            #region AutoMapper

            MapperConfiguration mapperConfiguration = new MapperConfiguration(mapperConfig =>
            {
                mapperConfig.AddMaps(new[] { "Senai.Service" });
            });
            builder.Services.AddSingleton(mapperConfiguration.CreateMapper());

            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}