namespace ByteFarm.SamplerTools.Midi.Core
{
    internal class MidiResponse : IMidiResponse
    {
        public MidiResponse(byte[] rawData)
        {
            RawData = rawData;
        }

        public byte[] RawData { get; }
    }
}