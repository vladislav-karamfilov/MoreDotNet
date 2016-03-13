namespace MoreDotNet.Extentions.Common
{
    using System;

    public static class OperatingSystemExtentions
    {
        /// <summary>
        /// Checks if the OS is Windows XP or higher.
        /// </summary>
        /// <param name="os">The <see cref="OperatingSystem"/> instance on which the extension method is called.</param>
        /// <returns>True if the OS is Windows XP or higher. False otherwise.</returns>
        public static bool IsWinXpOrHigher(this OperatingSystem os)
        {
            return (os.Platform == PlatformID.Win32NT)
              && ((os.Version.Major > 5) || ((os.Version.Major == 5) && (os.Version.Minor >= 1)));
        }

        /// <summary>
        /// Checks if the OS is Windows Vista or higher.
        /// </summary>
        /// <param name="os">The <see cref="OperatingSystem"/> instance on which the extension method is called.</param>
        /// <returns>True if the OS is Windows Vista or higher. False otherwise.</returns>
        public static bool IsWinVistaOrHigher(this OperatingSystem os)
        {
            return (os.Platform == PlatformID.Win32NT)
              && (os.Version.Major >= 6);
        }

        /// <summary>
        /// Checks if the OS is Windows 7 or higher.
        /// </summary>
        /// <param name="os">The <see cref="OperatingSystem"/> instance on which the extension method is called.</param>
        /// <returns>True if the OS is Windows 7 or higher. False otherwise.</returns>
        public static bool IsWin7OrHigher(this OperatingSystem os)
        {
            return (os.Platform == PlatformID.Win32NT)
              && ((os.Version.Major > 6) || ((os.Version.Major == 6) && (os.Version.Minor >= 1)));
        }

        /// <summary>
        /// Checks if the OS is Windows 8 or higher.
        /// </summary>
        /// <param name="os">The <see cref="OperatingSystem"/> instance on which the extension method is called.</param>
        /// <returns>True if the OS is Windows 8 or higher. False otherwise.</returns>
        public static bool IsWin8OrHigher(this OperatingSystem os)
        {
            return (os.Platform == PlatformID.Win32NT)
              && ((os.Version.Major > 6) || ((os.Version.Major == 6) && (os.Version.Minor >= 2)));
        }
    }
}
