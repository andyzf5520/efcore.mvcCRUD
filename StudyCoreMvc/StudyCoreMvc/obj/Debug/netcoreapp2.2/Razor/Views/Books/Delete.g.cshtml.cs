#pragma checksum "D:\工作\C#\StudyCoreMvc\StudyCoreMvc\Views\Books\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "956b59cdef8381c39a9c92d4497b2e852ce2da3f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Books_Delete), @"mvc.1.0.view", @"/Views/Books/Delete.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Books/Delete.cshtml", typeof(AspNetCore.Views_Books_Delete))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"956b59cdef8381c39a9c92d4497b2e852ce2da3f", @"/Views/Books/Delete.cshtml")]
    public class Views_Books_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<StudyCoreMvc.Models.BooksModels.Book>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(45, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "D:\工作\C#\StudyCoreMvc\StudyCoreMvc\Views\Books\Delete.cshtml"
  
    ViewData["Title"] = "Delete";

#line default
#line hidden
            BeginContext(89, 174, true);
            WriteLiteral("\r\n<h1>Delete</h1>\r\n\r\n<h3>Are you sure you want to delete this?</h3>\r\n<div>\r\n    <h4>Book</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(264, 40, false);
#line 15 "D:\工作\C#\StudyCoreMvc\StudyCoreMvc\Views\Books\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
            EndContext();
            BeginContext(304, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(368, 36, false);
#line 18 "D:\工作\C#\StudyCoreMvc\StudyCoreMvc\Views\Books\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Name));

#line default
#line hidden
            EndContext();
            BeginContext(404, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(467, 43, false);
#line 21 "D:\工作\C#\StudyCoreMvc\StudyCoreMvc\Views\Books\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Content));

#line default
#line hidden
            EndContext();
            BeginContext(510, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(574, 39, false);
#line 24 "D:\工作\C#\StudyCoreMvc\StudyCoreMvc\Views\Books\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Content));

#line default
#line hidden
            EndContext();
            BeginContext(613, 254, true);
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n    \r\n    <form asp-action=\"Delete\">\r\n        <input type=\"hidden\" asp-for=\"Id\" />\r\n        <input type=\"submit\" value=\"Delete\" class=\"btn btn-danger\" /> |\r\n        <a asp-action=\"Index\">Back to List</a>\r\n    </form>\r\n</div>\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<StudyCoreMvc.Models.BooksModels.Book> Html { get; private set; }
    }
}
#pragma warning restore 1591