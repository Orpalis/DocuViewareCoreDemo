using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace DocuViewareCoreDemo
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
            services.AddSession();
            services.AddMvc(option => option.EnableEndpointRouting = false); 
            services.AddRazorPages();

            if(string.IsNullOrWhiteSpace(Globals.API_KEY))
            {
                throw new System.Exception("Please specify your PassportPDF API KEY within the Globals.API_KEY constant");
            }

            PassportPDF.Client.GlobalConfiguration.BasePath = Globals.SERVEUR_URI;
            PassportPDF.Client.GlobalConfiguration.ApiKey = Globals.API_KEY;
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
             app.UseSession();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });


            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });

        }
    }
}