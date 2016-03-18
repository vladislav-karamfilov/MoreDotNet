namespace MoreDotNet.Wrappers
{
    using System;

    public static class DecimalWrappers
    {
        /// <summary>
        /// <see cref="string.IsNullOrWhiteSpace"/>
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static decimal Ceiling(this decimal input)
        {
            return decimal.Ceiling(input);
        }

        public static decimal Floor(this decimal input)
        {
            return decimal.Floor(input);
        }

        public static long ToOaCurrency(this decimal input)
        {
            return decimal.ToOACurrency(input);
        }

        public static byte ToByte(this decimal input)
        {
            return decimal.ToByte(input);
        }

        public static sbyte ToSByte(this decimal input)
        {
            return decimal.ToSByte(input);
        }

        public static short ToShort(this decimal input)
        {
            return decimal.ToInt16(input);
        }

        public static ushort ToUShort(this decimal input)
        {
            return decimal.ToUInt16(input);
        }

        public static int ToInt(this decimal input)
        {
            return decimal.ToInt32(input);
        }

        public static uint ToUInt(this decimal input)
        {
            return decimal.ToUInt32(input);
        }

        public static long ToLong(this decimal input)
        {
            return decimal.ToInt64(input);
        }

        public static ulong ToULong(this decimal input)
        {
            return decimal.ToUInt64(input);
        }

        public static float ToFloat(this decimal input)
        {
            return decimal.ToSingle(input);
        }

        public static double ToDouble(this decimal input)
        {
            return decimal.ToDouble(input);
        }

        public static int[] GetBits(this decimal input)
        {
            return decimal.GetBits(input);
        }

        public static decimal Round(this decimal input)
        {
            return decimal.Round(input);
        }

        public static decimal Round(this decimal input, int decimals)
        {
            return decimal.Round(input, decimals);
        }

        public static decimal Round(this decimal input, int decimals, MidpointRounding mode)
        {
            return decimal.Round(input, decimals, mode);
        }

        public static decimal Round(this decimal input, MidpointRounding mode)
        {
            return decimal.Round(input, mode);
        }

        public static decimal Truncate(this decimal input)
        {
            return decimal.Truncate(input);
        }
    }
}
