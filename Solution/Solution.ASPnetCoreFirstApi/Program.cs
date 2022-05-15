using System;
using System.Linq;
using Microsoft.Graph;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace Solution.ASPnetCoreFirstApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateHostBuilder(args).Build().Run();

            var builder = WebApplication.CreateBuilder();
            var app = builder.Build();

            app.Run(async (context) =>
            {
                var response = context.Response;
                var request = context.Request;
                var path = request.Path;
                //string expressionForNumber = "^/api/users/([0 - 9]+)$";   // если id представляет число

                // 2e752824-1657-4c7f-844b-6ec2e168e99c
                string expressionForGuid = @"^/api/users/\w{8}-\w{4}-\w{4}-\w{4}-\w{12}$";
                if (path == "/api/users" && request.Method == "GET")
                {
                    await GetAllPeople(response);
                }
                else if (Regex.IsMatch(path, expressionForGuid) && request.Method == "GET")
                {
                    // получаем id из адреса url
                    string? id = path.Value?.Split("/")[3];
                    await GetPerson(id, response, request);
                }
                else if (path == "/api/users" && request.Method == "POST")
                {
                    await CreatePerson(response, request);
                }
                else if (path == "/api/users" && request.Method == "PUT")
                {
                    await UpdatePerson(response, request);
                }
                else if (Regex.IsMatch(path, expressionForGuid) && request.Method == "DELETE")
                {
                    string? id = path.Value?.Split("/")[3];
                    await DeletePerson(id, response, request);
                }
                else
                {
                    response.ContentType = "text/html; charset=utf-8";
                    await response.SendFileAsync("html/index.html");
                }
            });

            app.Run();


        }

        //public static IHostBuilder CreateHostBuilder(string[] args) =>
        //    Host.CreateDefaultBuilder(args)
        //        .ConfigureWebHostDefaults(webBuilder =>
        //        {
        //            webBuilder.UseStartup<Startup>();
        //        });
    }
}
