using System;

namespace Rs.Dnevnik.Ris.Core.Utils
{
    public static class Extensions
    {
         public static string ConvertNewRowToHtml(this string input)
         {
             if (input == null) return null;
             return input.Replace(Environment.NewLine, "\n");
         }
    }
}