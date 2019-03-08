using System.ComponentModel;

namespace ByteFarm.SamplerTools.Midi.SysEx.Akai.S1000
{
    public enum S1000FunctionCode : byte
    {
        [Description("Request Stats")]RSTAT = 0x0,
        [Description("Stat Response")]STAT = 0x1,
        [Description("Request Program List")]RPLIST = 0x2,
        [Description("Program List Response")]PLIST = 0x3,
        [Description("Request Resident Sample List")]RSLIST = 0x4,
        [Description("Resident Sample List Response")]SLIST = 0x5,
        [Description("Request Program Common Data")]RPDATA = 0x6,
        [Description("Program Common Data Response")]PDATA = 0x7,
        [Description("Request Keygroup Data")]RKDATA = 0x8,
        [Description("Keygroup Data Response")]KDATA = 0x9,
        [Description("Request Sample Header Data")]RSDATA = 0xA,
        [Description("Sample Header Data Response")]SDATA = 0xB,
        [Description("Request Sample Data Packet")]RSPACK = 0xC,
        [Description("Sample Data Packet Response")]ASPACK = 0xD,
        [Description("Request Drum Input Settings")]RDDATA = 0xE,
        [Description("Drum Input Data Response")]DDATA = 0xD,
        [Description("Request Misc Data")]RMDATA = 0x10,
        [Description("Misc Data Response")]MDATA = 0x11,
        [Description("Request Delete Program and Keygroups")]DELP = 0x12,
        [Description("Request Delete Keygroup")]DELK = 0x13,
        [Description("Request Delete Sample Header and Data")]DELS = 0x14,
        [Description("Request Set SysEX Exclusive Channel")]SETEX = 0x15,
        [Description("Command Reply")]REPLY = 0x16,
        [Description("Corrected ASPACK?")]CASPACK = 0x1D
    }
}