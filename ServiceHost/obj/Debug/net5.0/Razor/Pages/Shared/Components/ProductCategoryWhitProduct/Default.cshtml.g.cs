#pragma checksum "D:\Code\LampShade\ServiceHost\Pages\Shared\Components\ProductCategoryWhitProduct\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a9cd7cf0a3caad932dec4b93e4285c636c86c3ab"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ServiceHost.Pages.Shared.Components.ProductCategoryWhitProduct.Pages_Shared_Components_ProductCategoryWhitProduct_Default), @"mvc.1.0.view", @"/Pages/Shared/Components/ProductCategoryWhitProduct/Default.cshtml")]
namespace ServiceHost.Pages.Shared.Components.ProductCategoryWhitProduct
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
#line 1 "D:\Code\LampShade\ServiceHost\Pages\_ViewImports.cshtml"
using ServiceHost;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9cd7cf0a3caad932dec4b93e4285c636c86c3ab", @"/Pages/Shared/Components/ProductCategoryWhitProduct/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"49bdd27e8b016acb3c031a38b8da4d14315ca499", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Shared_Components_ProductCategoryWhitProduct_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<_01_LampShadeQuery.Contracts.ProductCategory.ProductCategoryQueryModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-fluid"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral(@"
<div class=""single-row-slider-tab-area section-space"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-lg-12"">
                <!--=======  section title  =======-->
                <div class=""section-title-wrapper text-center section-space--half"">
                    <h2 class=""section-title"">محصولات ما</h2>
                    <p class=""section-subtitle"">
                        Mirum est notare quam littera gothica, quam nunc putamus parum
                        claram anteposuerit litterarum formas.
                    </p>
                </div>
                <!--=======  End of section title  =======-->
            </div>
        </div>
        <div class=""row"">
            <div class=""col-lg-12"">
                <!--=======  tab slider wrapper  =======-->

                <div class=""tab-slider-wrapper"">
                    <!--=======  tab product navigation  =======-->

                    <div class=""tab-product-navigation"">
            ");
            WriteLiteral("            <div class=\"nav nav-tabs justify-content-center\" id=\"nav-tab2\" role=\"tablist\">\r\n");
#nullable restore
#line 27 "D:\Code\LampShade\ServiceHost\Pages\Shared\Components\ProductCategoryWhitProduct\Default.cshtml"
                             foreach (var category in Model)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <a");
            BeginWriteAttribute("class", " class=\"", 1328, "\"", 1395, 3);
            WriteAttributeValue("", 1336, "nav-item", 1336, 8, true);
            WriteAttributeValue(" ", 1344, "nav-link", 1345, 9, true);
#nullable restore
#line 29 "D:\Code\LampShade\ServiceHost\Pages\Shared\Components\ProductCategoryWhitProduct\Default.cshtml"
WriteAttributeValue(" ", 1353, Model.First()==category? "active" : "", 1354, 41, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("id", " id=\"", 1396, "\"", 1425, 2);
            WriteAttributeValue("", 1401, "product-tab-", 1401, 12, true);
#nullable restore
#line 29 "D:\Code\LampShade\ServiceHost\Pages\Shared\Components\ProductCategoryWhitProduct\Default.cshtml"
WriteAttributeValue("", 1413, category.Id, 1413, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" data-toggle=\"tab\"");
            BeginWriteAttribute("href", "\r\n                               href=\"", 1444, "\"", 1511, 2);
            WriteAttributeValue("", 1483, "#product-series-", 1483, 16, true);
#nullable restore
#line 30 "D:\Code\LampShade\ServiceHost\Pages\Shared\Components\ProductCategoryWhitProduct\Default.cshtml"
WriteAttributeValue("", 1499, category.Id, 1499, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" role=\"tab\" aria-selected=\"true\">");
#nullable restore
#line 30 "D:\Code\LampShade\ServiceHost\Pages\Shared\Components\ProductCategoryWhitProduct\Default.cshtml"
                                                                                              Write(category.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n");
#nullable restore
#line 31 "D:\Code\LampShade\ServiceHost\Pages\Shared\Components\ProductCategoryWhitProduct\Default.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                        </div>\r\n                    </div>\r\n\r\n                    <!--=======  End of tab product navigation  =======-->\r\n                    <!--=======  tab product content  =======-->\r\n                    <div class=\"tab-content\">\r\n");
#nullable restore
#line 40 "D:\Code\LampShade\ServiceHost\Pages\Shared\Components\ProductCategoryWhitProduct\Default.cshtml"
                         foreach (var category in Model)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <div");
            BeginWriteAttribute("class", " class=\"", 1968, "\"", 2036, 4);
            WriteAttributeValue("", 1976, "tab-pane", 1976, 8, true);
            WriteAttributeValue(" ", 1984, "fade", 1985, 5, true);
            WriteAttributeValue(" ", 1989, "show", 1990, 5, true);
#nullable restore
#line 42 "D:\Code\LampShade\ServiceHost\Pages\Shared\Components\ProductCategoryWhitProduct\Default.cshtml"
WriteAttributeValue(" ", 1994, Model.First()==category? "active" : "", 1995, 41, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("id", " id=\"", 2037, "\"", 2069, 2);
            WriteAttributeValue("", 2042, "product-series-", 2042, 15, true);
#nullable restore
#line 42 "D:\Code\LampShade\ServiceHost\Pages\Shared\Components\ProductCategoryWhitProduct\Default.cshtml"
WriteAttributeValue("", 2057, category.Id, 2057, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" role=""tabpanel""
                        aria-labelledby=""product-tab-1"">
                            <!--=======  single row slider wrapper  =======-->
                        <div class=""single-row-slider-wrapper"">
                                <div class=""ht-slick-slider"" data-slick-setting='{
                                    ""slidesToShow"": 4,
                                    ""slidesToScroll"": 1,
                                    ""arrows"": true,
                                    ""autoplay"": false,
                                    ""autoplaySpeed"": 5000,
                                    ""speed"": 1000,
                                    ""infinite"": true,
                                    ""rtl"": true,
                                    ""prevArrow"": {""buttonClass"": ""slick-prev"", ""iconClass"": ""ion-chevron-left"" },
                                    ""nextArrow"": {""buttonClass"": ""slick-next"", ""iconClass"": ""ion-chevron-right"" }
                                }' data-slick-res");
            WriteLiteral(@"ponsive='[
                                    {""breakpoint"":1501, ""settings"": {""slidesToShow"": 4} },
                                    {""breakpoint"":1199, ""settings"": {""slidesToShow"": 4, ""arrows"": false} },
                                    {""breakpoint"":991, ""settings"": {""slidesToShow"": 3, ""arrows"": false} },
                                    {""breakpoint"":767, ""settings"": {""slidesToShow"": 2, ""arrows"": false} },
                                    {""breakpoint"":575, ""settings"": {""slidesToShow"": 2, ""arrows"": false} },
                                    {""breakpoint"":479, ""settings"": {""slidesToShow"": 1, ""arrows"": false} }
                                ]'>
");
#nullable restore
#line 65 "D:\Code\LampShade\ServiceHost\Pages\Shared\Components\ProductCategoryWhitProduct\Default.cshtml"
                                         foreach (var product in category.Products)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                            <div class=""col"">
                                                <!--=======  single grid product  =======-->
                                    <div class=""single-grid-product"">
                                                    <div class=""single-grid-product__image"">
");
#nullable restore
#line 71 "D:\Code\LampShade\ServiceHost\Pages\Shared\Components\ProductCategoryWhitProduct\Default.cshtml"
                                                         if(@product.HasDiscount)
                                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                            <div class=\"single-grid-product__lable\">\r\n                                                                <span class=\"sale\">");
#nullable restore
#line 74 "D:\Code\LampShade\ServiceHost\Pages\Shared\Components\ProductCategoryWhitProduct\Default.cshtml"
                                                                              Write(product.DiscountRate);

#line default
#line hidden
#nullable disable
            WriteLiteral("%</span>\r\n                                                                </div>\r\n");
#nullable restore
#line 76 "D:\Code\LampShade\ServiceHost\Pages\Shared\Components\ProductCategoryWhitProduct\Default.cshtml"
                                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <a href=\"single-product.html\">\r\n                                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "a9cd7cf0a3caad932dec4b93e4285c636c86c3ab12673", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 4864, "~/", 4864, 2, true);
#nullable restore
#line 78 "D:\Code\LampShade\ServiceHost\Pages\Shared\Components\ProductCategoryWhitProduct\Default.cshtml"
AddHtmlAttributeValue("", 4866, product.Picture, 4866, 16, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "title", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 78 "D:\Code\LampShade\ServiceHost\Pages\Shared\Components\ProductCategoryWhitProduct\Default.cshtml"
AddHtmlAttributeValue("", 4891, product.PictureTitle, 4891, 21, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "alt", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 78 "D:\Code\LampShade\ServiceHost\Pages\Shared\Components\ProductCategoryWhitProduct\Default.cshtml"
AddHtmlAttributeValue("", 4919, product.PictureAlt, 4919, 19, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                                    </a>\r\n\r\n");
            WriteLiteral(@"                                                </div>
                                                <div class=""single-grid-product__content"">
                                                    <div class=""single-grid-product__category-rating"">
                                                        <span class=""category"">
                                                            <a href=""shop-left-sidebar.html"">");
#nullable restore
#line 96 "D:\Code\LampShade\ServiceHost\Pages\Shared\Components\ProductCategoryWhitProduct\Default.cshtml"
                                                                                        Write(product.Category);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</a>
                                                        </span>
                                                        <span class=""rating"">
                                                            <i class=""ion-android-star active""></i>
                                                            <i class=""ion-android-star active""></i>
                                                            <i class=""ion-android-star active""></i>
                                                            <i class=""ion-android-star active""></i>
                                                            <i class=""ion-android-star-outline""></i>
                                                        </span>
                                                    </div>

                                                    <h3 class=""single-grid-product__title"">
                                                        <a href=""single-product.html"">
                                                           ");
#nullable restore
#line 109 "D:\Code\LampShade\ServiceHost\Pages\Shared\Components\ProductCategoryWhitProduct\Default.cshtml"
                                                      Write(product.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                        </a>\r\n                                                    </h3>\r\n                                                    <p class=\"single-grid-product__price\">\r\n");
#nullable restore
#line 113 "D:\Code\LampShade\ServiceHost\Pages\Shared\Components\ProductCategoryWhitProduct\Default.cshtml"
                                                         if(product.HasDiscount)
                                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                                <span class=\"discounted-price\">");
#nullable restore
#line 115 "D:\Code\LampShade\ServiceHost\Pages\Shared\Components\ProductCategoryWhitProduct\Default.cshtml"
                                                                                          Write(product.PriceWhitDiscount);

#line default
#line hidden
#nullable disable
            WriteLiteral(" تومان</span>\r\n                                                                <span class=\"main-price discounted\">");
#nullable restore
#line 116 "D:\Code\LampShade\ServiceHost\Pages\Shared\Components\ProductCategoryWhitProduct\Default.cshtml"
                                                                                               Write(product.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(" تومان</span>\r\n");
#nullable restore
#line 117 "D:\Code\LampShade\ServiceHost\Pages\Shared\Components\ProductCategoryWhitProduct\Default.cshtml"
                                                            }
                                                            else
                                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                                 <span class=\"main-price\">");
#nullable restore
#line 120 "D:\Code\LampShade\ServiceHost\Pages\Shared\Components\ProductCategoryWhitProduct\Default.cshtml"
                                                                                     Write(product.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(" تومان</span>\r\n");
#nullable restore
#line 121 "D:\Code\LampShade\ServiceHost\Pages\Shared\Components\ProductCategoryWhitProduct\Default.cshtml"
                                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                                           
                                                    </p>
                                                </div>
                                            </div>
                                            <!--=======  End of single grid product  =======-->
                                </div>
");
#nullable restore
#line 128 "D:\Code\LampShade\ServiceHost\Pages\Shared\Components\ProductCategoryWhitProduct\Default.cshtml"
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                </div>\r\n                                <!--=======  End of tab product content  =======-->\r\n                        </div>\r\n                          </div>  \r\n");
#nullable restore
#line 133 "D:\Code\LampShade\ServiceHost\Pages\Shared\Components\ProductCategoryWhitProduct\Default.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        








                        <!--=======  End of single row slider wrapper  =======-->
                        <!--=======  End of tab slider wrapper  =======-->
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<_01_LampShadeQuery.Contracts.ProductCategory.ProductCategoryQueryModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
