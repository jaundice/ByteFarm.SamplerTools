namespace ByteFarm.SamplerTools.Midi.Core
{
    public interface IMidiVoiceMessage : IMidiMessage
    {
        byte MidiChannel { get; }

        byte Byte1 { get; }
        byte? Byte2 { get; }
    }
}