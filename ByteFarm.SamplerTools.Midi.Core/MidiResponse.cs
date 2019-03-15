namespace ByteFarm.SamplerTools.Midi.Core
{
    public class MidiResponse : IMidiResponse
    {
        public MidiResponse(byte[] rawData)
        {
            RawData = rawData;
        }

        public byte[] RawData { get; }
    }
}