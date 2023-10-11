#pragma checksum "D:\HR Projects\FBCLikeOrNot\FBCLikeOrNot\Views\Admin\QuestionsGraph.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f51b5fc5966c9b6f14dc73ca91764a0a6ecc13e4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_QuestionsGraph), @"mvc.1.0.view", @"/Views/Admin/QuestionsGraph.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f51b5fc5966c9b6f14dc73ca91764a0a6ecc13e4", @"/Views/Admin/QuestionsGraph.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"80ea038eac41096afaedc28345e4e62ec188925e", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Admin_QuestionsGraph : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/App/Dashboard/DashboardApp.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "D:\HR Projects\FBCLikeOrNot\FBCLikeOrNot\Views\Admin\QuestionsGraph.cshtml"
  
    ViewData["Title"] = "QuestionsGraph";
    Layout = "~/Views/Shared/_DashboardLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            DefineSection("Styles", async() => {
                WriteLiteral("\r\n    <!-- Custom CSS -->\r\n    <link rel=\"stylesheet\" type=\"text/css\" href=\"https://cdn.jsdelivr.net/npm/daterangepicker/daterangepicker.css\" />\r\n");
            }
            );
            WriteLiteral(@"<div class=""container-fluid"" ng-app=""DashboardApp"" ng-controller=""DashboardController"">
    <div class=""col-12"">

        <!-- begin View Title -->
        <div class=""row"">
            <div class=""col-md-12 m-b-30"">
                <div class=""d-block d-lg-flex flex-nowrap align-items-center"">
                    <div class=""page-title mr-2 pr-4 border-right""><h1>Preguntas Por Area <i class=""fa fa-bar-chart text-primary""></i></h1></div>

                    <div class=""d-flex align-items-center secondary-menu text-center"" style=""margin-left:1%"">
                        <input type=""text"" name=""name"" ng-model=""SrchString"" class=""form-control"" placeholder=""Busqueda General"" />
                    </div>
                    <div class=""mr-2 pr-4 border-right text-primary"" id=""reportrange"" style=""background: #fff; cursor: pointer; padding: 5px 10px; border: 1px solid #ccc;"">
                        <i class=""fa fa-calendar""></i>&nbsp;
                        <span></span> <i class=""fa fa-caret-down");
            WriteLiteral(@"""></i>
                    </div>
                </div>
            </div>
        </div>
        <!-- End View Title -->

        <div class=""card card-statistics"">
            <div class=""card-body"">
                <div class=""table table-responsive table-hover table-borderless"">
                    <table class=""table mb-0"">
                        <thead class=""bg-primary"" style=""color:aliceblue"">
                            <tr>
                                <th scope=""col"">Area</th>
                                <th scope=""col"">Like Reaction</th>
                                <th scope=""col"">Meh Reaction</th>
                                <th scope=""col"">Bad Reaction</th>
                                <th scope=""col"">Total</th>
                                <th scope=""col"">Porcentaje Like</th>
                                <th scope=""col"">Porcentaje Meh</th>
                                <th scope=""col"">Porcentaje Bad</th>
                            </tr>
       ");
            WriteLiteral(@"                 </thead>
                        <tbody ng-repeat=""reaction in TotalReactionList | filter: SrchString"">
                            <tr>
                                <th>{{ reaction.nameservice }}</th>
                                <th>{{ reaction.goodTotalReactions }}</th>
                                <td>{{ reaction.neutralTotalReactions }}</td>
                                <td>{{ reaction.badTotalReactions }}</td>
                                <td>{{ reaction.totalReactions }}</td>
                                <td>{{ reaction.goodPercentage }} %</td>
                                <td>{{ reaction.neutralPercentage }} %</td>
                                <td>{{ reaction.badPercentage }} %</td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
        <div class=""card card-statistics"">

");
            WriteLiteral("            <div class=\"apexchart-wrapper\">\r\n                <div id=\"apexgraph\"></div>\r\n            </div>\r\n\r\n        </div>\r\n    </div>\r\n\r\n</div>\r\n\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral("\r\n\r\n    <script type=\"text/javascript\" src=\"https://cdn.jsdelivr.net/momentjs/latest/moment.min.js\"></script>\r\n    <script type=\"text/javascript\" src=\"https://cdn.jsdelivr.net/npm/daterangepicker/daterangepicker.min.js\"></script>\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f51b5fc5966c9b6f14dc73ca91764a0a6ecc13e47804", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
            }
            );
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
