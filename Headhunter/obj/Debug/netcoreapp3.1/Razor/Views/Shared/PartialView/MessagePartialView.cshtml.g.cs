#pragma checksum "C:\C#\Headhunter\Headhunter\Views\Shared\PartialView\MessagePartialView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1ac6fe29bd5d8c97ad20051c9e14fe5ed842f39c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_PartialView_MessagePartialView), @"mvc.1.0.view", @"/Views/Shared/PartialView/MessagePartialView.cshtml")]
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
#nullable restore
#line 2 "C:\C#\Headhunter\Headhunter\Views\Shared\PartialView\MessagePartialView.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1ac6fe29bd5d8c97ad20051c9e14fe5ed842f39c", @"/Views/Shared/PartialView/MessagePartialView.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ab57bca6a372b3a2cdfa2cc8c1b4058aaa168038", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_PartialView_MessagePartialView : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<User>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\C#\Headhunter\Headhunter\Views\Shared\PartialView\MessagePartialView.cshtml"
  
    var thisUserId = userManager.GetUserId(User);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div style=\"overflow-x: hidden; overflow-y: scroll;width: auto; height: 500px;  padding: 5px; border: solid 1px black;\" class=\"layer mt-5\">\r\n    <div id=\"result\"></div>\r\n</div>\r\n\r\n");
#nullable restore
#line 14 "C:\C#\Headhunter\Headhunter\Views\Shared\PartialView\MessagePartialView.cshtml"
 if (User.Identity.IsAuthenticated)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"mt-3\">\r\n        <a");
            BeginWriteAttribute("onclick", " onclick=\"", 408, "\"", 441, 3);
            WriteAttributeValue("", 418, "openForm(\'", 418, 10, true);
#nullable restore
#line 17 "C:\C#\Headhunter\Headhunter\Views\Shared\PartialView\MessagePartialView.cshtml"
WriteAttributeValue("", 428, thisUserId, 428, 11, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 439, "\')", 439, 2, true);
            EndWriteAttribute();
            WriteLiteral(" style=\"cursor: pointer\">??????????????????</a>\r\n    </div>\r\n    <div");
            BeginWriteAttribute("id", " id=\"", 502, "\"", 528, 2);
            WriteAttributeValue("", 507, "answerdiv-", 507, 10, true);
#nullable restore
#line 19 "C:\C#\Headhunter\Headhunter\Views\Shared\PartialView\MessagePartialView.cshtml"
WriteAttributeValue("", 517, thisUserId, 517, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"display:none\">\r\n        <input class=\"form-control\"");
            BeginWriteAttribute("id", " id=\"", 588, "\"", 615, 2);
            WriteAttributeValue("", 593, "answertext-", 593, 11, true);
#nullable restore
#line 20 "C:\C#\Headhunter\Headhunter\Views\Shared\PartialView\MessagePartialView.cshtml"
WriteAttributeValue("", 604, thisUserId, 604, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n        <input type=\"hidden\"");
            BeginWriteAttribute("id", " id=\"", 647, "\"", 670, 2);
            WriteAttributeValue("", 652, "userId-", 652, 7, true);
#nullable restore
#line 21 "C:\C#\Headhunter\Headhunter\Views\Shared\PartialView\MessagePartialView.cshtml"
WriteAttributeValue("", 659, thisUserId, 659, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("value", " value=\"", 671, "\"", 707, 1);
#nullable restore
#line 21 "C:\C#\Headhunter\Headhunter\Views\Shared\PartialView\MessagePartialView.cshtml"
WriteAttributeValue("", 679, userManager.GetUserId(User), 679, 28, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n        <input  class=\"btn btn-dark mb-5 mt-2\" type=\"button\" id=\"postComment\"");
            BeginWriteAttribute("onclick", " onclick=\"", 788, "\"", 824, 3);
            WriteAttributeValue("", 798, "sendMessage(\'", 798, 13, true);
#nullable restore
#line 22 "C:\C#\Headhunter\Headhunter\Views\Shared\PartialView\MessagePartialView.cshtml"
WriteAttributeValue("", 811, thisUserId, 811, 11, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 822, "\')", 822, 2, true);
            EndWriteAttribute();
            WriteLiteral(" value=\"??????????????????\"/>\r\n    </div>\r\n");
#nullable restore
#line 24 "C:\C#\Headhunter\Headhunter\Views\Shared\PartialView\MessagePartialView.cshtml"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager<User> userManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<User> Html { get; private set; }
    }
}
#pragma warning restore 1591
