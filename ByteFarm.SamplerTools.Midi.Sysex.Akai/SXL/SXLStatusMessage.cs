using System.IO;
using ByteFarm.SamplerTools.Midi.SysEx.Akai.S1000;
using ByteFarm.SamplerTools.Midi.SysEx.Common;

namespace ByteFarm.SamplerTools.Midi.SysEx.Akai.SXL
{
    public class SXLStatusMessage : AkaiStatusMessage
    {
        public SXLStatusMessage(byte uniqueDeviceId) : base(SXLSysExConstants.SXLDeviceTypeId, uniqueDeviceId)
        {
        }

        public override byte[] FormatToMidiBytes()
        {
            using (MemoryStream mem = new MemoryStream())
            using (BinaryWriter sr = new BinaryWriter(mem))
            {
                sr.Write(SysExConstants.SysExMessageEnd);
                sr.Write(AkaiConstants.AkaiManufacturerId);
                sr.Write(UniqueDeviceId);
                sr.Write((byte)S1000FunctionCode.RSTAT);
                sr.Write(SXLSysExConstants.SXLDeviceTypeId);
                sr.Write(SysExConstants.SysExMessageEnd);

                sr.Flush();
                return mem.ToArray();
            }
        }
    }
}
