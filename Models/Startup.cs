using Microsoft.AspNetCore.Mvc;

namespace routings.Models
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
                services.Configure<CookiePolicyOptions>(options =>
                {
                    // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                    options.CheckConsentNeeded = context => true;
                    options.MinimumSameSitePolicy = SameSiteMode.None;
                });


                services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            }

            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app, IHostEnvironment env)
            {
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                }
                else
                {
                    app.UseExceptionHandler("/Home/Error");
                }

                app.UseStaticFiles();
                app.UseCookiePolicy();

                app.UseMvc(routes =>
                {
                    routes.MapRoute(
                        name: "default",
                        template: "{controller=Home}/{action=Index}/{id?}");

                    routes.MapRoute(
                       name: "studentId",
                       template: "Student/{id}",
                      defaults: new { controller = "Home", action = "StudentInfo1" });



                    routes.MapRoute(
                       name: "studentIdName",
                       template: "Student/{id}/{name}",
                      defaults: new { controller = "Home", action = "StudentInfo1" });

                });
            }
        }
    }


