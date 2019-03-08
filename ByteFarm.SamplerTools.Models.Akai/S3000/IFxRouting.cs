namespace ByteFarm.SamplerTools.Models.Akai.S3000
{
    public interface IFxRouting
    {
        FxRoute FxRoute { get; set; }
        uint Send { get; }
    }
}