using System;

namespace Tests
{

    //specific to my own midi setup
    public static class TestConstants
    {
        public static readonly string S1100Port = Environment.OSVersion.Platform == PlatformID.Win32NT ? "DIN 1" :"Akai S1100";
        public static readonly string E5000Port = Environment.OSVersion.Platform == PlatformID.Win32NT ? "DIN 2": "E5000 Ultra";
        public static readonly string E6400Port = Environment.OSVersion.Platform == PlatformID.Win32NT ? "DIN 3" : "E6400 Ultra"; 
        public static readonly string S3000XLPort = Environment.OSVersion.Platform == PlatformID.Win32NT ? "DIN 4" : "S3000XL" ;
    }
}