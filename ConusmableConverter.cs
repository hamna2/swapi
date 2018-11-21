using System;
using SwapiApiChallenge.Exceptions;
using SwapiApiChallenge.Interfaces;

namespace SwapiApiChallenge
{
    public class ConusmableConverter : IConsumableConverter
    {
        private const int DaysInYear = 365;
        private const int DaysInMonth = 30;
        private const int DaysInWeek = 7;

        private const string Year = "year";
        private const string Month = "month";
        private const string Week = "week";
        private const string Day = "day";

        public int Convert(string consumables)
        {
            consumables = consumables.ToLower();
            if (consumables.Contains(Year))
            {
                return TryConvertToYear(consumables);
            }

            if (consumables.Contains(Month))
            {
                return TryConvertToMonth(consumables);
            }

            if (consumables.Contains(Week))
            {
                return TryConvertToWeek(consumables);
            }

            if (consumables.Contains(Day))
            {
                return TryConvertToDay(consumables);
            }

            throw new ConsumableFormatNotFoundException("Consumablable does not match Day/Week/Year Format.");
        }


        private int TryConvertToYear(string consumables)
        {
            var year = consumables.IndexOf(Year, StringComparison.OrdinalIgnoreCase);
            var yearValue = consumables.Substring(0, year);
            
            if (int.TryParse(yearValue, out var output))
            {
                return output * DaysInYear;
            }

            throw new ConsumableConversionExecption($"Can not convert the given consumable {consumables} to meaning full Dar/Week/Year");
        }

        private int TryConvertToMonth(string consumables)
        {
            var month = consumables.IndexOf(Month, StringComparison.OrdinalIgnoreCase);
            var monthValue = consumables.Substring(0, month);
            
            if (int.TryParse(monthValue, out var output))
            {
                return output * DaysInMonth;
            }
            throw new ConsumableConversionExecption($"Can not convert the given consumable {consumables} to meaning full Dar/Week/Year");
        }

        private int TryConvertToWeek(string consumables)
        {
            var week = consumables.IndexOf(Week, StringComparison.OrdinalIgnoreCase);
            var value = consumables.Substring(0, week);

            if (int.TryParse(value, out var output))
            {
                return output * DaysInWeek;
            }
            throw new ConsumableConversionExecption($"Can not convert the given consumable {consumables} to meaning full Dar/Week/Year");
        }

        private int TryConvertToDay(string consumables)
        {
            var day = consumables.IndexOf(Day, StringComparison.OrdinalIgnoreCase);
            var dayValue = consumables.Substring(0, day);

            if (int.TryParse(dayValue, out var output))
            {
                return output;
            }

            throw new ConsumableConversionExecption($"Can not convert the given consumable {consumables} to meaning full Dar/Week/Year");
        }

    }
}