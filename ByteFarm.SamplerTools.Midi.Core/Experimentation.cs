using System;
using ByteFarm.SamplerTools.Midi.Sysex.Akai.Z;
using ByteFarm.SamplerTools.Midi.Sysex.Common;
using Commons.Music.Midi;

namespace ByteFarm.SamplerTools.Midi.Core
{
    public class Experimentation
    {
        public void TestConnect()
        {
            IMidiAccess api = MidiAccessManager.Empty;
            IMidiOutput output = api.OpenOutputAsync("1").Result;

            byte[] msg = new byte[] { SysexConstants.SysexMessageStart, ZSysexConstants.Akai, ZSysexConstants.ZMPC4000DeviceTypeId, 0x0 };

            output.Send(msg, 0,msg.Length, DateTime.Now.Ticks);


        }
    }
}
