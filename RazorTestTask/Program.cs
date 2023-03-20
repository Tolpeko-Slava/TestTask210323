using RazorTestTask;
using RazorTestTask.Model;

using (ApplicationDateBase db = new ApplicationDateBase())
{
    db.Database.EnsureCreated();

    //Role roleAdmin = new Role { Name = "Admin" };
    //Role roleUser = new Role { Name = "User"};

    //db.Roles.Add(roleAdmin);
    //db.Roles.Add(roleUser);
    //db.SaveChanges();

    //User userAdmin = new User { Id = 0, Name = "Иван", Subname = "Иванович", Login = "toslav", Password = "132", Role = roleAdmin };
    //db.Users.Add(userAdmin);
    //db.SaveChanges();

}

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

var app = builder.Build();


app.UseStaticFiles();
app.UseRouting();
app.MapRazorPages();

app.Run();





/*
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }

    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
        }

        public void Configure(IApplicationBuilder app)
        {
           // app.UseDeveloperExceptionPage();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
*/