#pragma checksum "C:\Users\vicba\source\repos\Classrooms\Classrooms\Views\Course\CourseDetail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "08a148db5f73dfea168fa6aa4f8f8aef26435b74"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Course_CourseDetail), @"mvc.1.0.view", @"/Views/Course/CourseDetail.cshtml")]
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
#nullable restore
#line 1 "C:\Users\vicba\source\repos\Classrooms\Classrooms\Views\_ViewImports.cshtml"
using Classrooms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\vicba\source\repos\Classrooms\Classrooms\Views\_ViewImports.cshtml"
using Classrooms.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\vicba\source\repos\Classrooms\Classrooms\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"08a148db5f73dfea168fa6aa4f8f8aef26435b74", @"/Views/Course/CourseDetail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"90c36fc85685a39b9a1ea02ed184ff6dc3eeaf96", @"/Views/_ViewImports.cshtml")]
    public class Views_Course_CourseDetail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Classrooms.ViewModels.CourseDetailViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\vicba\source\repos\Classrooms\Classrooms\Views\Course\CourseDetail.cshtml"
   ViewData["Title"] = "Create Details"; 

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div>I am a course called ");
#nullable restore
#line 5 "C:\Users\vicba\source\repos\Classrooms\Classrooms\Views\Course\CourseDetail.cshtml"
                     Write(Model.CourseTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n\r\n<div>And here are da students in this course of sorts:</div>\r\n");
#nullable restore
#line 8 "C:\Users\vicba\source\repos\Classrooms\Classrooms\Views\Course\CourseDetail.cshtml"
 foreach (var student in Model.Participants)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div> ");
#nullable restore
#line 10 "C:\Users\vicba\source\repos\Classrooms\Classrooms\Views\Course\CourseDetail.cshtml"
     Write(student);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </div>\r\n");
#nullable restore
#line 11 "C:\Users\vicba\source\repos\Classrooms\Classrooms\Views\Course\CourseDetail.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager<ApplicationUser> userManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Classrooms.ViewModels.CourseDetailViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
