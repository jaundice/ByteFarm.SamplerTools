using System;

namespace Tests
{

    //specific to my own midi setup
    public static class TestConstants
    {
        public static readonly string S1100PortInput = Environment.OSVersion.Platform == PlatformID.Win32NT ? "DIN 1" :"Source0";
        public static readonly string E5000PortInput = Environment.OSVersion.Platform == PlatformID.Win32NT ? "DIN 2": "Source1";
        public static readonly string E6400PortInput = Environment.OSVersion.Platform == PlatformID.Win32NT ? "DIN 3" : "Source2"; 
        public static readonly string S3000XLPortInput = Environment.OSVersion.Platform == PlatformID.Win32NT ? "DIN 4" : "Source3";

        public static readonly string S1100PortOutput = Environment.OSVersion.Platform == PlatformID.Win32NT ? "DIN 1" : "Destination0";
        public static readonly string E5000PortOutput = Environment.OSVersion.Platform == PlatformID.Win32NT ? "DIN 2" : "Destination1";
        public static readonly string E6400PortOutput = Environment.OSVersion.Platform == PlatformID.Win32NT ? "DIN 3" : "Destination2";
        public static readonly string S3000XLPortOutput = Environment.OSVersion.Platform == PlatformID.Win32NT ? "DIN 4" : "Destination3";
    }
}