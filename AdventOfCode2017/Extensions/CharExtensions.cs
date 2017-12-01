﻿namespace AdventOfCode2017.Extensions
{
    public static class CharExtensions
    {
        public static bool IsNumeric(this char c)
        {
	        return char.IsDigit(c);
        }

        public static int ToInt(this char c)
        {
            return (int) char.GetNumericValue(c);
        }
    }
}
