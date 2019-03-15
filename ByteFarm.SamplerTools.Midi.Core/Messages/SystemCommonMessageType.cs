using System;
using System.Collections.Generic;
using System.Text;

namespace ByteFarm.SamplerTools.Midi.Core.Messages
{
    public enum SystemCommonMessageType : byte
    {
        MidiTimingCode = 0xF1,
        SongPositionPointer = 0xF2,
        SongSelect = 0xF3,
        TuneRequest = 0xF6
    }
}
