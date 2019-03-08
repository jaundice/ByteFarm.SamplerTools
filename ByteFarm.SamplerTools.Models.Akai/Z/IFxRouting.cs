namespace ByteFarm.SamplerTools.Models.Akai.Z
{
    public interface IFxRouting
    {
        FxRoute FxRoute { get; set; }
        uint Send { get; }
    }
}