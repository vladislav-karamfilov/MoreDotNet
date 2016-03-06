namespace MoreDotNet.Extentions.Common
{
    using System;

    public static class OperatingSystemExtentions
    {
        public static bool IsWinXpOrHigher(this OperatingSystem os)
        {
            return (os.Platform == PlatformID.Win32NT)
              && ((os.Version.Major > 5) || ((os.Version.Major == 5) && (os.Version.Minor >= 1)));
        }

        public static bool IsWinVistaOrHigher(this OperatingSystem os)
        {
            return (os.Platform == PlatformID.Win32NT)
              && (os.Version.Major >= 6);
        }

        public static bool IsWin7OrHigher(this OperatingSystem os)
        {
            return (os.Platform == PlatformID.Win32NT)
              && ((os.Version.Major > 6) || ((os.Version.Major == 6) && (os.Version.Minor >= 1)));
        }

        public static bool IsWin8OrHigher(this OperatingSystem os)
        {
            return (os.Platform == PlatformID.Win32NT)
              && ((os.Version.Major > 6) || ((os.Version.Major == 6) && (os.Version.Minor >= 2)));
        }
    }
}
