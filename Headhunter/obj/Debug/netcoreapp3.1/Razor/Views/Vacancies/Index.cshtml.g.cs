#pragma checksum "C:\C#\Headhunter\Headhunter\Views\Vacancies\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a3d9212a96dc376452fd8ecd24fbbeeb0661ff2c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Vacancies_Index), @"mvc.1.0.view", @"/Views/Vacancies/Index.cshtml")]
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
#line 1 "C:\C#\Headhunter\Headhunter\Views\_ViewImports.cshtml"
using Headhunter;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\C#\Headhunter\Headhunter\Views\_ViewImports.cshtml"
using Headhunter.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a3d9212a96dc376452fd8ecd24fbbeeb0661ff2c", @"/Views/Vacancies/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ab57bca6a372b3a2cdfa2cc8c1b4058aaa168038", @"/Views/_ViewImports.cshtml")]
    public class Views_Vacancies_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Vacancy>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\C#\Headhunter\Headhunter\Views\Vacancies\Index.cshtml"
  
    ViewBag.Title = "Вакансия";
    Layout = "_Layout";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Подробности вакансии</h2>\r\n<h3>Название вакансии: ");
#nullable restore
#line 9 "C:\C#\Headhunter\Headhunter\Views\Vacancies\Index.cshtml"
                  Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n<h3>Описание :");
#nullable restore
#line 10 "C:\C#\Headhunter\Headhunter\Views\Vacancies\Index.cshtml"
         Write(Model.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n<h3>Категория : ");
#nullable restore
#line 11 "C:\C#\Headhunter\Headhunter\Views\Vacancies\Index.cshtml"
           Write(Model.Category.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n<h3>Требуемый опыт : ");
#nullable restore
#line 12 "C:\C#\Headhunter\Headhunter\Views\Vacancies\Index.cshtml"
                Write(Model.WorkExperience);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n<h3>Зарплата : ");
#nullable restore
#line 13 "C:\C#\Headhunter\Headhunter\Views\Vacancies\Index.cshtml"
          Write(Model.Salary);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n<h3>Дата создания/обновления :");
#nullable restore
#line 14 "C:\C#\Headhunter\Headhunter\Views\Vacancies\Index.cshtml"
                         Write(Model.DateOfCreator);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </h3>\r\n<h3>Доступность к публикации :");
#nullable restore
#line 15 "C:\C#\Headhunter\Headhunter\Views\Vacancies\Index.cshtml"
                         Write(Model.IsPublic);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </h3>\r\n<h3>Работодатель : ");
#nullable restore
#line 16 "C:\C#\Headhunter\Headhunter\Views\Vacancies\Index.cshtml"
              Write(Model.Employer);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n\r\n\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Vacancy> Html { get; private set; }
    }
}
#pragma warning restore 1591