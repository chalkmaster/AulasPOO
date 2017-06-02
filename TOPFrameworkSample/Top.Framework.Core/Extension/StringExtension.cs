using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Top.Framework.Core.Extension
{
    public static class StringExtension
    {
        private static readonly Regex EmailExpression = new Regex(@"^([0-9a-zA-Z]+[-._+&])*[0-9a-zA-Z]+@([-0-9a-zA-Z]+[.])+[a-zA-Z]{2,6}$", RegexOptions.Singleline | RegexOptions.Compiled);

        public static string FormatWith(this string s, params object[] p)
        {
            return String.Format(s, p);
        }

        [DebuggerStepThrough]
        public static bool IsEmail(this string target)
        {
            return !string.IsNullOrWhiteSpace(target) && EmailExpression.IsMatch(target);
        }
    }
}
