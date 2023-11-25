using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace BucksCoffeeShop.TagHelpers;

[HtmlTargetElement("header", ParentTag = "offcanvas")]
public class OffCanvasHeaderTagHelper: TagHelper
{
    public override async Task ProcessAsync(TagHelperContext context, 
        TagHelperOutput output)
    {
        var childData = (await output.GetChildContentAsync()).GetContent();

        output.TagName = "div";
        output.Attributes.Add("class", "offcanvas-header");

        var header = new TagBuilder("h5")
        {
            TagRenderMode = TagRenderMode.Normal
        };
        header.Attributes.Add("id", "offcanvasLabel");
        header.AddCssClass("offcanvas-title");
        header.InnerHtml.Append(childData);

        var button = new TagBuilder("button")
        {
            TagRenderMode = TagRenderMode.Normal
        };
        button.AddCssClass("btn-close");
        button.Attributes.Add("type","button");
        button.Attributes.Add("data-bs-dismiss","offcanvas");
        button.Attributes.Add("aria-label","Close");

        output.Content.AppendHtml(header);
        output.Content.AppendHtml(button);
    }
}