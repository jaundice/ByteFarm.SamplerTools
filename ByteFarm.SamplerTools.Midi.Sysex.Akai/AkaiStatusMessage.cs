using ByteFarm.SamplerTools.Midi.SysEx.Common;

namespace ByteFarm.SamplerTools.Midi.SysEx.Akai
{
    public abstract class AkaiStatusMessage : StatusMessageBase
    {
        public override byte ManufacturerId => AkaiConstants.AkaiManufacturerId;
    }
}