using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Data.SqlClient;

namespace WebDinamicoManuale
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                var path = context.Request.Path.Value;
                await context.Response.WriteAsync(BuildResponse(path));
            });
        }

        private string BuildResponse(string path)
        {
            var response =
                @"<!DOCTYPE html>
                <html>
                    <head>
                        <meta charset='utf-8' />
                        <title></title>
                    </head>
                    <body>";

            if (path == "/")
            {
                response +=
                    @"<h1>Corso Ires 2017</h1>
                    <p>
                        <a href='/valutazioni'>Valutazione insegnanti</a>
                    </p>";
            }
            else if (path == "/valutazioni")
            {
                var teachers = GetTeacherFromDatabase();

                response +=
                    @"<h1>Valutazioni 2017:</h1>
                        <ul>";

                foreach(var t in teachers)
                {
                    response += $"<li><a href='/valutazioni/{t.Id}'>{t.Name}: {t.Rating} stelle</a></li>";
                }
                            
                response += "</ul>";
            }
            else
            {
                throw new InvalidOperationException();
            }
             
            response +=       
                @"</body>
            </html>";

            return response;
        }

        private List<Teacher> GetTeacherFromDatabase()
        {
            using (var conn = new SqlConnection("Server=192.168.9.219;Database=ValutazioneCorsi;User Id=corso;Password=corso;"))
            using (var comm = conn.CreateCommand())
            {
                comm.CommandType = System.Data.CommandType.Text;
                comm.CommandText = "SELECT Id, Name, Rating FROM Insegnanti ORDER BY Name";

                conn.Open();

                using (var reader = comm.ExecuteReader())
                {
                    var teacherList = new List<Teacher>();

                    while(reader.Read())
                    {
                        var t = new Teacher();
                        t.Id = (int)reader["Id"];
                        t.Name = (string)reader["Name"];
                        t.Rating = (int)reader["Rating"];

                        teacherList.Add(t);
                    }

                    return teacherList;
                }
            }
        }
    }
}
