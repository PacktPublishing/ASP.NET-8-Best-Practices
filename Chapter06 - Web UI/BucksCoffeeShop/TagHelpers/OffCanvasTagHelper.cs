using Microsoft.AspNetCore.Razor.TagHelpers;

namespace BucksCoffeeShop.TagHelpers;

[HtmlTargetElement("offcanvas")]
public class OffCanvasTagHelper: TagHelper
{
    [HtmlAttributeName("id")]
    public string Id { get; set; }

    [HtmlAttributeName("tabindex")]
    public string TabIndex { get; set; }

    public override async Task ProcessAsync(TagHelperContext context, 
        TagHelperOutput output)
    {
        var childData = (await output.GetChildContentAsync()).GetContent();
        
        output.Attributes.Clear();
        output.TagName = "div";
        output.Attributes.Add("class", "offcanvas offcanvas-start");

        if (!string.IsNullOrEmpty(Id))
        {
            output.Attributes.Add("id ", Id);
        }

        if (!string.IsNullOrEmpty(TabIndex))
        {
            output.Attributes.Add("tabindex", TabIndex);
        }

        output.Content.SetHtmlContent(childData);
    }
}
