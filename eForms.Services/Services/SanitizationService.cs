using AutoMapper;
using eForms.Domain.Context;
using eForms.Domain.Enums;
using eForms.Domain.Models;
using eForms.Services.Interfaces;
using Ganss.XSS;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eForms.Services.Services
{
    public class SanitizationService : ISanitizationService
    {
        HtmlSanitizer sanitizer;
        public SanitizationService()
        {
            sanitizer = new HtmlSanitizer();
            sanitizer.AllowedAtRules.Clear();
            sanitizer.AllowedAttributes.Clear();
            sanitizer.AllowedClasses.Clear();
            sanitizer.AllowedCssProperties.Clear();
            sanitizer.AllowedSchemes.Clear();
            sanitizer.AllowedTags.Clear();

            sanitizer.AllowedTags.Add("p");
            sanitizer.AllowedTags.Add("strong");
            sanitizer.AllowedTags.Add("em");
            sanitizer.AllowedTags.Add("span");
            sanitizer.AllowedAttributes.Add("style");
            sanitizer.AllowedTags.Add("a");
            sanitizer.AllowedAttributes.Add("href");
            sanitizer.AllowedAttributes.Add("text-align");
            sanitizer.AllowedTags.Add("ol");
            sanitizer.AllowedTags.Add("ul");
            sanitizer.AllowedTags.Add("li");
            sanitizer.AllowedAttributes.Add("padding-left");
            sanitizer.AllowedTags.Add("sup");
            sanitizer.AllowedTags.Add("sub");
            sanitizer.AllowedTags.Add("code");
            sanitizer.AllowedTags.Add("blockquote");
            sanitizer.AllowedTags.Add("div");
            sanitizer.AllowedTags.Add("pre");
            sanitizer.AllowedTags.Add("h1");
            sanitizer.AllowedTags.Add("h2");
            sanitizer.AllowedTags.Add("h3");
            sanitizer.AllowedTags.Add("h4");
            sanitizer.AllowedTags.Add("h5");
            sanitizer.AllowedTags.Add("h6");
        }

        public string Sanitize(string html)
        {
            return sanitizer.Sanitize(html);
        }
    }
}
