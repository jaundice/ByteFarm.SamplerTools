using System;

namespace ByteFarm.SamplerTools.Midi.Core
{
    public class MidiResponseReceivedEventArgs : EventArgs
    {
        public MidiResponseReceivedEventArgs(IMidiResponse response)
        {
            Response = response;
        }

        public IMidiResponse Response { get; }
    }
}