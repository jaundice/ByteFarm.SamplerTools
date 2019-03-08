using ByteFarm.SamplerTools.Midi.SysEx.Common;

namespace ByteFarm.SamplerTools.Midi.SysEx.Akai
{
    public abstract class AkaiStatusMessage : StatusMessageBase
    {
        protected AkaiStatusMessage(byte deviceTypeId, byte uniqueDeviceId) : base(AkaiConstants.AkaiManufacturerId,
            deviceTypeId, uniqueDeviceId)
        {
        }
    }
}