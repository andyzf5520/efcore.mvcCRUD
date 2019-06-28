using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudyCoreMvc.Models;

namespace StudyCoreMvc.Controllers
{
    public class HomeController : Controller
    {
        public readonly StudyCoreMvcContext _studyCoreMvcContext;
        private readonly IDateTime _dateTime;   //手动高亮
        public HomeController(StudyCoreMvcContext studyCoreMvcContext,IDateTime dateTime)
        {
            _dateTime = dateTime;
            this._studyCoreMvcContext = studyCoreMvcContext;
        }

        //  过滤器
        unsafe  // 添加之后指针不会报错
        public IActionResult Index()
        {
            var Art=   _studyCoreMvcContext.Article.ToList();
            var serverTime = _dateTime.Now; //手动高亮
            if (serverTime.Hour < 12)       //手动高亮
            {
                ViewData["Message"] = "It's morning here - 早上好!";  //手动高亮
            }
            else if (serverTime.Hour < 17)  //手动高亮
            {
                ViewData["Message"] = "It's afternoon here - 下午好!";  //手动高亮
            }
            else    //手动高亮
            {
                ViewData["Message"] = "It's evening here - 晚上好!";  //手动高亮
            }
            string s1 = "He said, \"This is the last \u0063hance\x0021\"";
            string s2 = @"He said, ""This is the last \u0063hance\x0021""";
            string name = "Mark";
            var date = DateTime.Now;

            // Composite formatting:
            //$ -字符串内插（C# 参考）
            Console.WriteLine("Hello, {0}! Today is {1}, it's {2:HH:mm} now.", name, date.DayOfWeek, date);
            Console.WriteLine($"Hello ,{name} ! Today is {date.DayOfWeek} , it's {date:HH:mm} Now");
            string strs = $"Hello, {name}! Today is {date.DayOfWeek}, it's {date:HH:mm} now.";
            ViewBag.s1 = s1;
            ViewBag.s2 = s2;
            ViewBag.s3 = strs;            //Console.WriteLine(s1);
                                          // 一元操作符查看指针地址
            int number = 27;
             int* pointerToNumber = &number;
            ViewBag.address = (long)(pointerToNumber);

            //Console.WriteLine(s2);
            return View(Art);
        }
        // 依赖注入实现

    }

}