namespace ByteFarm.SamplerTools.Midi.Core.Messages
{
    public enum ChannelVoiceMessageType : byte
    {
        NoteOff = 0x8,
        NoteOn = 0x9,
        PolyphonicKeyPressure = 0xA,
        ControlChange = 0xB,
        ProgramChange = 0xC,
        ChannelPressure = 0xD,
        PitchBend = 0xE
    }
}