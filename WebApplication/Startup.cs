using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WebApplication.Models;
using Microsoft.EntityFrameworkCore; // пространство имен EntityFramework

namespace WebApplication
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AddressContext>(options => options.UseSqlServer(connection));
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            // обработка ошибок HTTP
            app.UseStatusCodePagesWithReExecute("/errors/{0}.html");

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

           // вызываем инициализатор. После первого запуска закомментировать
           // SampleData.Initialize(app.ApplicationServices);
        }
    }

    public class SampleData
    {
        static RandomNotRepeat rndCityStreet = new RandomNotRepeat(0, 20);
        static RandomNotRepeat rndCountry = new RandomNotRepeat(0, 4);
        static Random rndIndex = new Random(DateTime.Now.Millisecond);

        static DateTime GetRandomDate(DateTime from, DateTime to, Random random = null)
        {
            if (from >= to)
            {
                throw new Exception("Параметр \"from\" должен быть меньше параметра \"to\"!");
            }
            if (random == null)
            {
                random = new Random();
            }
            TimeSpan range = to - from;
            var randts = new TimeSpan((long)(random.NextDouble() * range.Ticks));
            return from + randts;
        }                

        protected static string GetRandomStreet()
        {
            string[] cityRus = new string[20] { "Гончарова", "Вахитова", "Льва Толстого", "Гая", "Победы", "Тора", "Капитана Америки", "Самурая", "Ницши", "Харакири", "Винни Пуха", "Сэма Смита", "Диего Капоне", "Дона Карлеонэ", "Марка Твена", "Акита", "Оцу", "Химедзи", "Нара", "Гоголя" };
            return cityRus[rndCityStreet.Next()];
        }

        protected static string GetRandomCity()
        {
            string[] cityRus = new string[20] { "Ульяновск", "Москва", "Казань", "Самара", "Саратов", "Торонто", "Монреаль", "Оттава", "Ванкувер", "Виннипег", "Нью-Йорк", "Хьюстон", "Чикаго", "Детройт", "Бостон", "Акита", "Оцу", "Химедзи", "Нара", "Токио" };
            return cityRus[rndCityStreet.Next()];
        }

        protected static string GetRandomCountry()
        {
            string[] country = new string[4] { "Россия", "США", "Канада", "Япония" };
            return country[rndCountry.Next()];
        }

        protected static int GetRandomIndex()
        {
            return rndIndex.Next(100000, 555555);
        }

        protected static int GetRandomBuilding()
        {
            return rndIndex.Next(1, 50);
        }
        

        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<AddressContext>();
            for (int i = 0; i < 1000; i++) //число фейковых строк
            {
                //add lines
                context.Addreses.Add(new Address {
                    Country = GetRandomCountry(),
                    Stereet = GetRandomStreet(),
                    City = GetRandomCity(),
                    BuildingNumber = GetRandomBuilding(),
                    PostID = GetRandomIndex(),
                    DateTime = GetRandomDate(new DateTime(1900, 1, 1, 1, 1, 1), new DateTime(2019, 1, 1, 1, 1, 1), rndIndex)
                });
            }
            context.SaveChanges();
        }
    }
}