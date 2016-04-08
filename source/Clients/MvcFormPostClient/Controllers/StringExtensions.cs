using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcFormPostClient.Controllers
{
    internal static class StringExtensions
    {
        public static string EnsureTrailingSlash(this string input)
        {
            if (!input.EndsWith("/"))
            {
                return input + "/";
            }

            return input;
        }
    }
}