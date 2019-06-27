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
        public HomeController(StudyCoreMvcContext studyCoreMvcContext)
        {

            this._studyCoreMvcContext = studyCoreMvcContext;
        }
        public IActionResult Index()
        {
            var Art=   _studyCoreMvcContext.Article.ToList();
            return View(Art);
        }
    }
}