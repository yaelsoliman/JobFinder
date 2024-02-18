using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobFinder.Application.Common.Extensions;
public static class StringExtensions
{
    public static bool IsEmpty(this string? input)
    {
        return string.IsNullOrEmpty(input);
    }

    public static bool HasValue(this string? input)
    {
        return !input.IsEmpty();
    }

    public static bool HasValue(this string? input, string search, bool lowerCase = true)
    {
        if (input.HasValue())
        {
            return lowerCase ? input!.ToLower().Contains(search) : input!.Contains(search);
        }

        return false;
    }
}
