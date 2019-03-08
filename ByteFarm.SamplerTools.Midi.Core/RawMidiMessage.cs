namespace ByteFarm.SamplerTools.Midi.Core
{
    public class RawMidiMessage : IMidiMessage
    {
        private readonly byte[] _rawData;

        public RawMidiMessage(byte[] rawData)
        {
            _rawData = rawData;
        }

        public byte[] FormatToMidiBytes()
        {
            return _rawData;
        }
    }
}