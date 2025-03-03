﻿using System;

namespace MediaFlyout.Extensions
{
    public enum OSVersions : int
    {
        VER_19H1 = 18362,
        VER_20H2 = 19042,

        VER_11_21H2 = 22000,
        VER_11_22H2 = 22621,
    }

    public static class OperatingSystemExtensions
    {
        public static bool IsAtLeast(this OperatingSystem os, OSVersions version)
        {
            return os.Version.Build >= (int)version;
        }

        public static bool IsGreaterThan(this OperatingSystem os, OSVersions version)
        {
            return os.Version.Build > (int)version;
        }

        public static bool IsLessThan(this OperatingSystem os, OSVersions version)
        {
            return os.Version.Build < (int)version;
        }

        public static bool IsWindows11(this OperatingSystem os)
        {
            return Environment.OSVersion.IsAtLeast(OSVersions.VER_11_21H2);
        }
    }
}
