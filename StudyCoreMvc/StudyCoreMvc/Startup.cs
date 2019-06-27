using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using StudyCoreMvc.Models;
using Microsoft.Extensions.Logging;

namespace StudyCoreMvc
{

    public class Startup
    {
        /// <summary>
        /// Startup文件中执行方法的步骤使用A，B，C，D表示
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        /// <summary>
        /// 步骤B  各种服务依赖注册的地方，netcore还是配置依赖注入方式为主
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            ///  dotnet ef migrations add Initial    dotnet ef database update 

            //添加mvc服务，没有这个mvc运行不起
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<StudyCoreMvcContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("StudyCoreMvcContext")));

                //这里还有其他注入方式
               //services.AddSingleton<>();//单例注入
               //services.AddScoped<>();//作用域注入
               //services.AddMemoryCache(); //MemoryCache缓存注入
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //添加Console输出
      
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

            //app.UseMvc(); // 这是默认Vs建的MVC 下面是VSCode建立的自带路由配置及文件夹Controller
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}"); //这里的{id?} ？号表示可以有可无
            });
        }
    }
}
