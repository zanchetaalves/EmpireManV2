using Microsoft.AspNetCore.Mvc.Razor;
using System;

namespace EmpireMan.App.Extensions
{
    public static class RazorExtensions
    {
        public static string FormataDocumento(this RazorPage page, string documento)
        {
            return Convert.ToUInt64(documento).ToString(@"000\.000\.000\-00");
        }

        public static string DataReduzida(this RazorPage page, DateTime data)
        {
            return data.ToString("dd/MM/yyyy");
        }

        public static string FormataCep(this RazorPage page, string documento)
        {
            return string.Format(documento, "00.000-000");
        }
    }
}