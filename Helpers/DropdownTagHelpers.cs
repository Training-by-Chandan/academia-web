using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TagHelpers.Helpers
{
    [HtmlTargetElement("dropdown-helper")]
    public class DropdownTagHelpers : TagHelper
    {
        public string id { get; set; }
        public string Name { get; set; }
        public List<(string,string)> items { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            (string, int, string, double) t = ("", 1, "",0);
            
            output.TagName = "div";
            output.Attributes.Add(new TagHelperAttribute("class", "dropdown"));
            output.TagMode = TagMode.StartTagAndEndTag;

            
            var str = new StringBuilder();

            str.Append($"<button class=\"btn btn-secondary dropdown-toggle\" type=\"button\" id=\"{id}\" data-toggle=\"dropdown\" aria-haspopup=\"true\" aria-expanded=\"false\">{Name}</button>");
            str.Append($"<div class=\"dropdown-menu\" aria-labelledby=\"{id}\">");
            
            
            foreach (var item in items)
            {
                str.Append($"<a class=\"dropdown-item\" href=\"{item.Item1}\">{item.Item2}</a>");
            }
            
            str.Append("</div>");

            output.PreContent.SetHtmlContent(str.ToString());

        }
    }
}
