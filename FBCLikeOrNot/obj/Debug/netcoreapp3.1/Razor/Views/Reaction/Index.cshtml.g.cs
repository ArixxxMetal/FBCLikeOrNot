#pragma checksum "C:\Users\Arisito\source\repos\FBCLikeOrNot\FBCLikeOrNot\Views\Reaction\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "046d0f0e0893d7624bb6c8d00b4e2483393a8d7e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Reaction_Index), @"mvc.1.0.view", @"/Views/Reaction/Index.cshtml")]
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
#line 1 "C:\Users\Arisito\source\repos\FBCLikeOrNot\FBCLikeOrNot\Views\_ViewImports.cshtml"
using FBCLikeOrNot;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Arisito\source\repos\FBCLikeOrNot\FBCLikeOrNot\Views\_ViewImports.cshtml"
using FBCLikeOrNot.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"046d0f0e0893d7624bb6c8d00b4e2483393a8d7e", @"/Views/Reaction/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"80ea038eac41096afaedc28345e4e62ec188925e", @"/Views/_ViewImports.cshtml")]
    public class Views_Reaction_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\Arisito\source\repos\FBCLikeOrNot\FBCLikeOrNot\Views\Reaction\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_ReactionLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Reaction </h1>\r\n\r\n<div class=\"row\">\r\n    <div class=\"col-xl-4 col-sm-6\">\r\n        <div class=\"card card-statistics\">\r\n            <div class=\"card-body\">\r\n                <div class=\"text-center p-2\">\r\n                    <div class=\"mb-2\">\r\n");
            WriteLiteral("                        <button type=\"button\" class=\"custombutton customsuccess\"><i class=\"fa fa-smile-o\" style=\"font-size: 1.90em;\"></i></button>\r\n");
            WriteLiteral(@"                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class=""col-xl-4 col-sm-6"">
        <div class=""card card-statistics"">
            <div class=""card-body"">
                <div class=""text-center p-2"">
                    <div class=""mb-2"">
                        <button type=""button"" class=""custombutton customwarning""><i class=""fa fa-meh-o"" style=""font-size: 1.90em;""></i></button>
                    </div>

                </div>
            </div>
        </div>
    </div>

    <div class=""col-xl-4 col-sm-6"">
        <div class=""card card-statistics"">
            <div class=""card-body"">
                <div class=""text-center p-2"">
                    <div class=""mb-2"">
                        <button type=""button"" class=""custombutton customdanger""><i class=""fa fa-frown-o"" style=""font-size: 1.90em;""></i></button>
                    </div>
                </div>
            </div>
        </div>
    </div>
    
</div>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
