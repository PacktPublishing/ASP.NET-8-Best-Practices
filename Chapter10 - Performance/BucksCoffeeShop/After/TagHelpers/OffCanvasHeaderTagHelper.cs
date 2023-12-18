using System.Web;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace BucksCoffeeShopAfter.TagHelpers;

[HtmlTargetElement("header", ParentTag = "offcanvas")]
public class OffCanvasHeaderTagHelper: TagHelper
{
    public OffCanvasHeaderTagHelper() { }

    public override async Task ProcessAsync(TagHelperContext context, 
        TagHelperOutput output)
    {
        output.TagName = "div";
        output.Attributes.Add("class", "offcanvas-header");

        var childContent = output.Content.IsModified 
            ? output.Content.GetContent()
            : (await output.GetChildContentAsync()).GetContent();

        var header = new TagBuilder("h5")
        {
            TagRenderMode = TagRenderMode.Normal
        };
        var headerAttributes = new AttributeDictionary
        {
            { "class", "offcanvas-title" },
            { "id", "offcanvaslabel" }
        };
        header.MergeAttributes(headerAttributes);
        header.InnerHtml.AppendHtml(childContent);

        var button = new TagHelperOutput("button", [
                new("type", "button"),
                new("data-bs-dismiss", "offcanvas"),
                new("aria-label", "Close"),
                new("class", "btn-close")
            ],
            (_, _) => Task.Factory.StartNew<TagHelperContent>(
                () => new DefaultTagHelperContent()));

        output.Content.SetHtmlContent(header);
        output.PostContent.SetHtmlContent(button);
    }
}
