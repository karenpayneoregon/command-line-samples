using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace myage.Extensions
{
    public static class DateTimeExtensions
    {
        public static bool CheckDate(this DateTime input, DateTime given)
        {
            var from = new DateTime(input.Year, input.Month, input.Day);
            var to = new DateTime(given.Year, given.Month, given.Day);

            return @from == to || to > @from;
        }
    }
}
