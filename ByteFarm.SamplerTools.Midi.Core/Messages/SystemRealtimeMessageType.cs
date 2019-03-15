namespace ByteFarm.SamplerTools.Midi.Core.Messages
{
    public enum SystemRealtimeMessageType : byte
    {
        TimingClock = 0xF8,
        StartSequence = 0xFA,
        ContinueSequence = 0xFB,
        StopSequence = 0xFC,
        ActiveSensing = 0xFE,
        SystemReset = 0xFF
    }
}