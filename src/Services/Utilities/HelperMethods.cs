using OfficeOpenXml.Drawing.Chart;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace Utilities
{
    public static class HelperMethods
    {

        /// <summary>
        /// Static operation to get the name of the method calling this method
        /// </summary>
        /// <param name="name"></param>
        /// <returns>The name of the method that is currently being called</returns>
        public static string GetCallerMemberName([CallerMemberName] string name = "")
        {
            return name;
        }


        /// <summary>
        /// Return a provide date formatted to a string for usage with SQL query parameters
        /// </summary>
        /// <param name="date">Date in question to format</param>
        /// <returns>A date string formatted to yyyy-MM-dd HH:mm:ss</returns>
        public static string GenerateSQLFormattedDate(DateTime date)
        {
            return date.ToString("yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// Used to ensure that the provided value is converted to upper, trimmed and also any whitespace in the value is removed.
        /// </summary>
        /// <param name="value">The value to be affected.</param>
        /// <returns>Returns the value after it has been updated.</returns>
        public static string ToUpperAndTrimAndRemoveWhiteSpace(this string value)
        {
            return value.ToUpper().Trim().Replace(" ", string.Empty);
        }

        /// <summary>
        /// Checks if the strings passed through match.
        /// </summary>
        /// <param name="val1">First string to be checked.</param>
        /// <param name="val2">Second string to be checked.</param>
        /// <returns>A boolean that states whether the strings match.</returns>
        public static bool Matches(this string val1, string val2)
        {
            return val1.ToUpper().Trim() == val2.ToUpper().Trim();
        }
    }
}