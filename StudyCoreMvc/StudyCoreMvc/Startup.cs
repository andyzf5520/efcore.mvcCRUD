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
        /// 
        /*
         依赖项注入通过以下办法解决这些问题:
        使用接口来抽象依赖项实现。
        在服务容器中注册依赖项。ASP.NET核心提供内置服务容器IServiceProvider。服务在应用的方法中注册。Startup.ConfigureServices
        将服务注入使用它的类的构造函数。框架负责创建依赖项的实例,并在不再需要时将其处理。
             */
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
            // 注册实例化上下文地方 
            services.AddDbContext<StudyCoreMvcContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("StudyCoreMvcContext")));
            //services.AddSingleton(typeof(ILogger<T>), typeof(Logger<T>));
            //Startup 类的 ConfigureServices 方法中配置服务。要指定请求 IDateTime 时使用 SystemDateTime 的实例来解析，
            //添加下面的清单中高亮的行到你的 ConfigureServices 方法中：
            //services.AddTransient<IDateTime,SystemDateTime>();
            //也可以这么写
            services.AddTransient(typeof(IDateTime), typeof(SystemDateTime));

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
    //public class ILogger<T> : B<T> where T : IEnumerable {
        
        
    //   }
    public class MyDependency : IMyDependency
    {
        private readonly ILogger<MyDependency> _logger;

        public MyDependency(ILogger<MyDependency> logger)
        {
            _logger = logger;
            /*
             MyDependency在其构造函数中请求一个ILogger_lt;TcategoryName>。
             以链式方式使用依赖项注入并不罕见。
             每个请求的依赖项依次请求其自己的依赖项。
             容器解析图形中的依赖项并返回完全解析的服务。必须解析的一组依赖项通常称为依赖项树、依赖关系图或对象图。
             IMyDependency必须在服务容器中注册。 在 中注册。 由日志记录抽象基础结构注册,因此它是框架默认注册的框架提供的服务。
             */
        }

        public Task WriteMessage(string message)
        {
            _logger.LogInformation(
                "MyDependency.WriteMessage called. Message: {MESSAGE}",
                message);

            return Task.FromResult(0);
        }
    }
    public interface IMyDependency
    {
        Task WriteMessage(string message);
    }
    public class Logger : ILogger
    {
        public IDisposable BeginScope<TState>(TState state)
        {
            throw new NotImplementedException();
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            throw new NotImplementedException();
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            throw new NotImplementedException();
        }
    }

    // 例子二
    public interface IDateTime
    {
        DateTime Now { get; }
    }
    public class SystemDateTime : IDateTime
    {
        public DateTime Now { get { return DateTime.Now; }  }
    }
}
