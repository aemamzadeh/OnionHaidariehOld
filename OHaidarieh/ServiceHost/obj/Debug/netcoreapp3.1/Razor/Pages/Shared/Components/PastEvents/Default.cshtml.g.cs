#pragma checksum "D:\NetCoreProjects\repos\OHaidarieh\OHaidarieh\ServiceHost\Pages\Shared\Components\PastEvents\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bd6ebbc89b33c777dd6e75d752a00c7c0102e5c2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ServiceHost.Pages.Shared.Components.PastEvents.Pages_Shared_Components_PastEvents_Default), @"mvc.1.0.view", @"/Pages/Shared/Components/PastEvents/Default.cshtml")]
namespace ServiceHost.Pages.Shared.Components.PastEvents
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
#line 1 "D:\NetCoreProjects\repos\OHaidarieh\OHaidarieh\ServiceHost\Pages\_ViewImports.cshtml"
using ServiceHost;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bd6ebbc89b33c777dd6e75d752a00c7c0102e5c2", @"/Pages/Shared/Components/PastEvents/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d027006424b9e12b1709732f146fce9f1d78e6a1", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Shared_Components_PastEvents_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<_01_HaidariehQuery.Contracts.CeremonyGuests.CeremonyGuestQueryModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/MultimediaDetail/Detail", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<div class=""gap remove-gap"">
    <div class=""container"">
        <div class=""evnt-pry-wrap"">
            <div class=""row"">
                <div class=""col-md-12 col-sm-12 col-lg-12"">
                    <div class=""sec-title"">
                        <div class=""sec-title2 text-center"">
                            <h3>رویدادهای<span> اخیر </span></h3>
                        </div>
                        <p>حیدریة النجف الاشرف حیدریة النجف الاشرف رویداد های مختلفی در طول سال برگزار میکند.</p>
                    </div>
                    <div class=""evnt-wrap remove-ext5"">
                        <div class=""row mrg20"">
");
#nullable restore
#line 16 "D:\NetCoreProjects\repos\OHaidarieh\OHaidarieh\ServiceHost\Pages\Shared\Components\PastEvents\Default.cshtml"
                             foreach (var item in Model)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <div class=\"col-md-4 col-sm-4 col-lg-4\">\r\n                                    <div class=\"evnt-box\">\r\n                                        <div class=\"evnt-thmb\">\r\n                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bd6ebbc89b33c777dd6e75d752a00c7c0102e5c24696", async() => {
                WriteLiteral("\r\n                                                <img");
                BeginWriteAttribute("src", " src=\"", 1174, "\"", 1191, 1);
#nullable restore
#line 22 "D:\NetCoreProjects\repos\OHaidarieh\OHaidarieh\ServiceHost\Pages\Shared\Components\PastEvents\Default.cshtml"
WriteAttributeValue("", 1180, item.Image, 1180, 11, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                BeginWriteAttribute("title", " title=\"", 1192, "\"", 1216, 1);
#nullable restore
#line 22 "D:\NetCoreProjects\repos\OHaidarieh\OHaidarieh\ServiceHost\Pages\Shared\Components\PastEvents\Default.cshtml"
WriteAttributeValue("", 1200, item.ImageTitle, 1200, 16, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("><img");
                BeginWriteAttribute("alt", "  alt=\"", 1222, "\"", 1243, 1);
#nullable restore
#line 22 "D:\NetCoreProjects\repos\OHaidarieh\OHaidarieh\ServiceHost\Pages\Shared\Components\PastEvents\Default.cshtml"
WriteAttributeValue("", 1229, item.ImageAlt, 1229, 14, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-Id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 21 "D:\NetCoreProjects\repos\OHaidarieh\OHaidarieh\ServiceHost\Pages\Shared\Components\PastEvents\Default.cshtml"
                                                                                    WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["Id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-Id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["Id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                        </div>\r\n                                        <div class=\"evnt-info\">\r\n                                            <h4>");
#nullable restore
#line 26 "D:\NetCoreProjects\repos\OHaidarieh\OHaidarieh\ServiceHost\Pages\Shared\Components\PastEvents\Default.cshtml"
                                           Write(item.Ceremony);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                                            <ul class=\"pst-mta\">\r\n                                                <li class=\"thm-clr\">");
#nullable restore
#line 28 "D:\NetCoreProjects\repos\OHaidarieh\OHaidarieh\ServiceHost\Pages\Shared\Components\PastEvents\Default.cshtml"
                                                               Write(item.CeremonyDate);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</li>
                                                <li class=""thm-clr"">12:00 صبح تا 2:00 ظهر</li>
                                            </ul>
                                            <p>شهر اصلی - بخش جدید - مسجد تازه ساخت</p>
                                        </div>
                                    </div>
                                </div>
");
#nullable restore
#line 35 "D:\NetCoreProjects\repos\OHaidarieh\OHaidarieh\ServiceHost\Pages\Shared\Components\PastEvents\Default.cshtml"

                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n                    </div><!-- Events Wrap -->\r\n                </div>\r\n\r\n            </div>\r\n        </div><!-- Events & Prayer Wrap -->\r\n    </div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<_01_HaidariehQuery.Contracts.CeremonyGuests.CeremonyGuestQueryModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
