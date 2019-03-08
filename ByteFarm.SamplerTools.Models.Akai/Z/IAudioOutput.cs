namespace ByteFarm.SamplerTools.Models.Akai.Z
{
    public interface IAudioOutput
    {
        OutputChannel OutputChannel { get; set; }
        OutputState OutputState { get; set; }
        short Pan { get; set; }
    }
}