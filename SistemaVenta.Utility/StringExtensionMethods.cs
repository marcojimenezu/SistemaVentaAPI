using System.Globalization;

namespace SistemaVenta.Utility;

public static class StringExtensionMethods
{
    public static string ToMXString(this decimal value) => Convert.ToString(value, new CultureInfo("es-MX"));
    public static string ToMXString(this int value) => Convert.ToString(value, new CultureInfo("es-MX"));
}