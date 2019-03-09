namespace ByteFarm.SamplerTools.Midi.Core
{
    public interface IMidiMessage
    {
        byte[] FormatToMidiBytes();
        int Offset { get; }
        int Length { get; }
    }
}