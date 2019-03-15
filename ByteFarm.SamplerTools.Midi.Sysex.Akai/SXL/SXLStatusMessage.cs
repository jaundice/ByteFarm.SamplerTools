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
                sr.Write((byte)SysExConstants.SysExMessageStart); //0xF0
                sr.Write((byte)AkaiConstants.AkaiManufacturerId); //0x47
                sr.Write((byte)UniqueDeviceId); //exclusive id
                sr.Write((byte)S1000FunctionCode.RSTAT); //function code
                sr.Write((byte)SXLSysExConstants.SXLDeviceTypeId); // 0x48 S1000
                sr.Write((byte)SysExConstants.SysExMessageEnd); //0xF7

                sr.Flush();

                var ret = mem.ToArray();
                return ret;
            }
        }
    }
}
