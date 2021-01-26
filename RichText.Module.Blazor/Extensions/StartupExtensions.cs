using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.DependencyInjection;
using RichText.Module.Blazor.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace RichText.Module.Blazor.Extensions {
    public static class StartupExtensions {
        public static IServiceCollection AddRichTextBlazorModule(this IServiceCollection services) {
            services.AddTransient<ITagHelperComponent, LinkTagHelperComponent>();
            return services;
        }
    }
}
