#pragma checksum "D:\NetCoreProjects\repos\OHaidarieh\OHaidarieh\ServiceHost\Pages\Shared\Components\Banners\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c0781d0f77e94f8a0cb8a62e35ff9edecb1b1ff4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ServiceHost.Pages.Shared.Components.Banners.Pages_Shared_Components_Banners_Default), @"mvc.1.0.view", @"/Pages/Shared/Components/Banners/Default.cshtml")]
namespace ServiceHost.Pages.Shared.Components.Banners
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c0781d0f77e94f8a0cb8a62e35ff9edecb1b1ff4", @"/Pages/Shared/Components/Banners/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4345c41bd16e78353c9c72df8b0b5549e39f6121", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Shared_Components_Banners_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<_01_HaidariehQuery.Contracts.Ceremonies.CeremonyQueryModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"gap no-gap clearfix\">\r\n    <img class=\"botm-shp shp-img\" src=\"theme/assets/images/shp2-1.png\" alt=\"shp2-1.png\">\r\n    <div class=\"featured-area-wrap text-center\">\r\n        <a class=\"contact-btn\" href=\"index.html#\"");
            BeginWriteAttribute("title", " title=\"", 299, "\"", 307, 0);
            EndWriteAttribute();
            WriteLiteral("><i class=\"flaticon-comment\"></i>تماس با ما</a>\r\n        <div class=\"featured-area2 owl-carousel\">\r\n\r\n");
#nullable restore
#line 9 "D:\NetCoreProjects\repos\OHaidarieh\OHaidarieh\ServiceHost\Pages\Shared\Components\Banners\Default.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"featured-item style2\"");
            BeginWriteAttribute("style", " style=\"", 520, "\"", 562, 4);
            WriteAttributeValue("", 528, "background-image:", 528, 17, true);
            WriteAttributeValue(" ", 545, "url(", 546, 5, true);
#nullable restore
#line 11 "D:\NetCoreProjects\repos\OHaidarieh\OHaidarieh\ServiceHost\Pages\Shared\Components\Banners\Default.cshtml"
WriteAttributeValue("", 550, item.Image, 550, 11, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 561, ")", 561, 1, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                        <div class=\"featured-cap\">\r\n                            <img src=\"theme/assets/images/resources/bsml-txt.png\" alt=\"bsml-txt.png\">\r\n");
            WriteLiteral("                            <h3>");
#nullable restore
#line 15 "D:\NetCoreProjects\repos\OHaidarieh\OHaidarieh\ServiceHost\Pages\Shared\Components\Banners\Default.cshtml"
                           Write(item.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                            <h4 class=\"text-white\">");
#nullable restore
#line 16 "D:\NetCoreProjects\repos\OHaidarieh\OHaidarieh\ServiceHost\Pages\Shared\Components\Banners\Default.cshtml"
                                              Write(item.CeremonyDateFa);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                            <h4 class=\"text-white\">ساعت:<span>");
#nullable restore
#line 17 "D:\NetCoreProjects\repos\OHaidarieh\OHaidarieh\ServiceHost\Pages\Shared\Components\Banners\Default.cshtml"
                                                         Write(item.CeremonyTime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></h4>\r\n\r\n");
#nullable restore
#line 19 "D:\NetCoreProjects\repos\OHaidarieh\OHaidarieh\ServiceHost\Pages\Shared\Components\Banners\Default.cshtml"
                             if (!System.Convert.IsDBNull(item.CeremonyDate))
                            {
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 21 "D:\NetCoreProjects\repos\OHaidarieh\OHaidarieh\ServiceHost\Pages\Shared\Components\Banners\Default.cshtml"
                                 if (item.IsLive && (DateTime.Compare(item.CeremonyDate, DateTime.Now) < 0))
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <a class=\"btn btn-danger brd-rd5\" href=\"http://www.aparat.com\"");
            BeginWriteAttribute("title", " title=\"", 1420, "\"", 1428, 0);
            EndWriteAttribute();
            WriteLiteral(">پخش زنده</a>\r\n");
#nullable restore
#line 24 "D:\NetCoreProjects\repos\OHaidarieh\OHaidarieh\ServiceHost\Pages\Shared\Components\Banners\Default.cshtml"
                                }
                                else if (item.IsLive && (DateTime.Compare(item.CeremonyDate, DateTime.Now) > 0))
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <a class=\"btn btn-dark brd-rd5\"");
            BeginWriteAttribute("title", " title=\"", 1695, "\"", 1703, 0);
            EndWriteAttribute();
            WriteLiteral(">پخش زنده</a>\r\n");
#nullable restore
#line 28 "D:\NetCoreProjects\repos\OHaidarieh\OHaidarieh\ServiceHost\Pages\Shared\Components\Banners\Default.cshtml"
                                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 28 "D:\NetCoreProjects\repos\OHaidarieh\OHaidarieh\ServiceHost\Pages\Shared\Components\Banners\Default.cshtml"
                                 
                            }
                            

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </div>\r\n                    </div>\r\n");
#nullable restore
#line 33 "D:\NetCoreProjects\repos\OHaidarieh\OHaidarieh\ServiceHost\Pages\Shared\Components\Banners\Default.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div><!-- Featured Area Wrap -->\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<_01_HaidariehQuery.Contracts.Ceremonies.CeremonyQueryModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
