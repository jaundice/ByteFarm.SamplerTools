namespace ByteFarm.SamplerTools.Models.Akai.S3000
{
    public interface IAudioOutput
    {
        OutputChannel OutputChannel { get; set; }
        OutputState OutputState { get; set; }
        short Pan { get; set; }
    }
}