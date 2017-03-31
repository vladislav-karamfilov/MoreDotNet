namespace MoreDotNet.Wrappers
{
    public static class LongWarppers
    {
        public static decimal FromOaCurrency(this long input)
        {
            return decimal.FromOACurrency(input);
        }
    }
}
