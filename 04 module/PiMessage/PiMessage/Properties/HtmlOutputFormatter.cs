using System;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace PiMessage.Properties
{
    /// <summary>
    /// Formatter for diplaying html pages.
    /// </summary>
    public class HtmlOutputFormatter : StringOutputFormatter
    {
        public HtmlOutputFormatter()
        {
            SupportedMediaTypes.Add("text/html");
        }
    }
}
