using System.IO;
using ByteFarm.SamplerTools.Midi.SysEx.Common;

namespace ByteFarm.SamplerTools.Midi.SysEx.Akai.Z
{
    public class ZStatusMessage : AkaiStatusMessage
    {
        public ZStatusMessage(byte uniqueDeviceId) : base(ZSysExConstants.ZMPC4000DeviceTypeId, uniqueDeviceId)
        {
        }

        public override byte[] FormatToMidiBytes()
        {
            using (var mem = new MemoryStream())
            using (var sr = new BinaryWriter(mem))
            {
                sr.Write(SysExConstants.SysExMessageStart);
                sr.Write(ManufacturerId);
                sr.Write(DeviceTypeId);
                sr.Write(UniqueDeviceId);
                sr.Write(SysExConstants.SysExMessageEnd);

                return mem.ToArray();
            }
        }
    }
}