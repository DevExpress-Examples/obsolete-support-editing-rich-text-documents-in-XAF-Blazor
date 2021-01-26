using DevExpress.Spreadsheet;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RichText.Module.Blazor.Helper {
    [HtmlTargetElement("head")]
    class LinkTagHelperComponent : TagHelperComponent {
        private string style = "<link href=\"_content/RichText.Module.Blazor/styles.css\" rel=\"stylesheet\" />";
        private string script = "<script src=\"_content/RichText.Module.Blazor/scripts.js\" ></script>";
        private string styleRich = "<link href=\"_content/RichText.Module.Blazor/dx.richedit.css\" rel=\"stylesheet\" />";
        private string scriptRich = "<script src=\"_content/RichText.Module.Blazor/dx.richedit.min.js\" ></script>";
        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output) {
            if (string.Equals(context.TagName, "head", StringComparison.OrdinalIgnoreCase)) {
                output.PostContent.AppendHtml(styleRich).AppendLine();
                output.PostContent.AppendHtml(style).AppendLine();
                output.PostContent.AppendHtml(scriptRich).AppendLine();
                output.PostContent.AppendHtml(script).AppendLine();
            }
            return Task.CompletedTask;
        }
    }
}
