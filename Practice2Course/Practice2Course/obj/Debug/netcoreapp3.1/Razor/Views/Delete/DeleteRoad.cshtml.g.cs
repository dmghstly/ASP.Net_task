#pragma checksum "C:\Users\Dmitriy Makarov\source\repos\Practice2Course\Practice2Course\Views\Delete\DeleteRoad.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0ad3ee1ea401ae116176de34d2f7ff1b7f0d9792"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Delete_DeleteRoad), @"mvc.1.0.view", @"/Views/Delete/DeleteRoad.cshtml")]
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
#line 3 "C:\Users\Dmitriy Makarov\source\repos\Practice2Course\Practice2Course\Views\Delete\DeleteRoad.cshtml"
using Practice2Course.Data;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0ad3ee1ea401ae116176de34d2f7ff1b7f0d9792", @"/Views/Delete/DeleteRoad.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b853c2693020103458b52d8246f923ca3fd89014", @"/Views/_ViewImports.cshtml")]
    public class Views_Delete_DeleteRoad : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Practice2Course.Data.Models.RoadSystem>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DeleteRoad", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-horizontal"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("<!DOCTYPE html>\r\n");
            WriteLiteral("\r\n<h1>Удаление улицы</h1>\r\n\r\n<div class=\"col-md-7 col-lg-8\">\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0ad3ee1ea401ae116176de34d2f7ff1b7f0d97924215", async() => {
                WriteLiteral("\r\n        <div class=\"row featurette\">\r\n            <div class=\"col-md-7 order-md-2\">\r\n                <h2 class=\"featurette-heading\">");
#nullable restore
#line 11 "C:\Users\Dmitriy Makarov\source\repos\Practice2Course\Practice2Course\Views\Delete\DeleteRoad.cshtml"
                                          Write(HelpElements.Abbs[Model.TypeId]);

#line default
#line hidden
#nullable disable
                WriteLiteral(" ");
#nullable restore
#line 11 "C:\Users\Dmitriy Makarov\source\repos\Practice2Course\Practice2Course\Views\Delete\DeleteRoad.cshtml"
                                                                           Write(Model.StreetName);

#line default
#line hidden
#nullable disable
                WriteLiteral(", ");
#nullable restore
#line 11 "C:\Users\Dmitriy Makarov\source\repos\Practice2Course\Practice2Course\Views\Delete\DeleteRoad.cshtml"
                                                                                              Write(HelpElements.CitiesDictionary[Model.CityId]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h2>\r\n                <p class=\"lead\">");
#nullable restore
#line 12 "C:\Users\Dmitriy Makarov\source\repos\Practice2Course\Practice2Course\Views\Delete\DeleteRoad.cshtml"
                           Write(Model.Description);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n            </div>\r\n            <div class=\"col-md-5 order-md-1\">\r\n                <img class=\"img-thumbnail\"");
                BeginWriteAttribute("src", " src=\"", 631, "\"", 650, 1);
#nullable restore
#line 15 "C:\Users\Dmitriy Makarov\source\repos\Practice2Course\Practice2Course\Views\Delete\DeleteRoad.cshtml"
WriteAttributeValue("", 637, Model.ImgUrl, 637, 13, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("/>\r\n\r\n            </div>\r\n        </div>\r\n        <input class=\"my-4 btn btn-danger\" type=\"submit\" value=\"Удалить улицу\" />\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Practice2Course.Data.Models.RoadSystem> Html { get; private set; }
    }
}
#pragma warning restore 1591
