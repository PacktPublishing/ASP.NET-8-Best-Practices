using Microsoft.AspNetCore.Razor.TagHelpers;

namespace BucksCoffeeShop.TagHelpers;

[HtmlTargetElement("body", ParentTag = "offcanvas")]
public class OffCanvasBodyTagHelper: TagHelper
{
    public override async Task ProcessAsync(TagHelperContext context, 
        TagHelperOutput output)
    {
        var childData = (await output.GetChildContentAsync()).GetContent();

        output.TagName = "div";
        output.Attributes.Add("class", "offcanvas-body");

        output.Content.SetHtmlContent(childData);
    }
}