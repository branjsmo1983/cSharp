using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
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
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

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
   @" <!DOCTYPE html> 
    <html>
        <head>
        <metacharset='utf-8'/>
        <title></title>
        </head>
        <body>";

            if(path == "/")
            {
                response += @" <h1>CorsoIres2017</h1>
                <p>
                    <a href='/valutazioni'>ValutazioneInsegnanti</a>
                </p>";
            }
            else if (path == "/valutazioni")
            {


                response += @"<h1>Valutazioni 2017</h1>
    <ul>
        <li><a href=' / valutazioni / daniel - maran.html'>Daniel Maran: 5 stelle</a></li>
              <li><a href = '/valutazioni/massimiliano-kraus.html' > Massimiliano Kraus: 2 stelle </a></li>
             
                     <li> Giovanni Buffa: 5 stelle </li>
                
                    </ul> ";
            }
            else
            {
                throw new InvalidOperationException();
            }
      response +=
        @"</body>
    </html> ";
            return response;
        }

        private List<Teacher> GetTeachersFromDatabase()
        {
            using (var conn = new SqlConnection("Server=192.168.9.219;Database=Corsi;User Id=corso;Password=corso;"))
        }
    }
}
