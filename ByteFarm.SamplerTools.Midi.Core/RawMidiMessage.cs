namespace ByteFarm.SamplerTools.Midi.Core
{
    public class RawMidiMessage : IMidiMessage
    {
        private readonly byte[] _rawData;

        public RawMidiMessage(byte[] rawData, int offset, int length)
        {
            _rawData = rawData;
            Offset = offset;
            Length = length;
        }

        public byte[] FormatToMidiBytes()
        {
            return _rawData;
        }

        public int Offset { get; }
        public int Length { get; }
    }
}