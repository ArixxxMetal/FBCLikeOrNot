#pragma checksum "D:\HR Projects\FBCLikeOrNot\FBCLikeOrNot\Views\Admin\Login.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "018a756a6566ea052e3b259a7fd1e04ca0e74f2f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_Login), @"mvc.1.0.view", @"/Views/Admin/Login.cshtml")]
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
#line 1 "D:\HR Projects\FBCLikeOrNot\FBCLikeOrNot\Views\_ViewImports.cshtml"
using FBCLikeOrNot;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\HR Projects\FBCLikeOrNot\FBCLikeOrNot\Views\_ViewImports.cshtml"
using FBCLikeOrNot.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"018a756a6566ea052e3b259a7fd1e04ca0e74f2f", @"/Views/Admin/Login.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"80ea038eac41096afaedc28345e4e62ec188925e", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_Login : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("px-5 mt-3"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "D:\HR Projects\FBCLikeOrNot\FBCLikeOrNot\Views\Admin\Login.cshtml"
  
    ViewData["Title"] = "Login";
    Layout = "~/Views/Shared/_LoginLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral(@"<div class=""app-contant"">
    <div class=""bg-white comingsoon"">
        <div class=""container-fluid p-0"">
            <div class=""row no-gutters"">
                <div class=""col-lg-6 align-self-center bg-gradient"">
                    <div class=""d-flex align-items-center h-100-vh"">
                        <div class=""comingsoon-wrap w-100"">
                            <div class=""row no-gutters align-items-center justify-content-center"">
                                <div class=""col-md-10 text-center m-b-40"">

                                    <!-- Login text -->
                                    <div class=""px-5"">
                                        <h2 class=""text-white display-3 font-weight-normal"">Iniciar Sesión</h2>
                                        <span class=""text-white"">Bienvenido, por favor ingrese sus credenciales...</span>
                                    </div>

                                    <!-- newsletter -->
                                    <div c");
            WriteLiteral("lass=\"row no-gutters\">\r\n                                        <div class=\"col-md-7 mx-auto\">\r\n                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "018a756a6566ea052e3b259a7fd1e04ca0e74f2f5402", async() => {
                WriteLiteral(@"
                                                <div class=""row"">
                                                    <div class=""col-12"">
                                                        <div class=""form-group"">
                                                            <label class=""control-label""><strong>Usuario*</strong></label>
                                                            <input type=""text"" class=""form-control bg-white-inverse"" placeholder=""Usuario"">
                                                        </div>
                                                    </div>
                                                    <div class=""col-12"">
                                                        <div class=""form-group"">
                                                            <label class=""control-label""><strong>Contraseña*</strong></label>
                                                            <input type=""password"" class=""form-control bg-white-inverse"" placeh");
                WriteLiteral(@"older=""Contraseña"">
                                                        </div>
                                                    </div>
                                                    <div class=""col-12"">
                                                        <div class=""d-block d-sm-flex  align-items-center"">
                                                            <div class=""form-check"">
                                                                <input class=""form-check-input"" type=""checkbox"" id=""gridCheck"">
                                                                <label class=""form-check-label"" for=""gridCheck"">
                                                                    Remember Me
                                                                </label>
                                                            </div>
                                                        </div>
                                                    </div>
                    ");
                WriteLiteral(@"                                <div class=""col-12 mt-3"">
                                                        <a href=""index.html"" class=""btn btn-round btn-outline-light"">Sign In</a>
                                                    </div>
                                                </div>
                                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                                        </div>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class=""col-lg-6 align-self-end"">
                    <img class=""img-fluid"" src=""assets/img/bg/coming-soon-bg.svg""");
            BeginWriteAttribute("alt", " alt=\"", 4112, "\"", 4118, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
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
