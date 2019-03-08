using System.Linq;
using System.Threading.Tasks;
using ByteFarm.SamplerTools.Midi.SysEx.Akai;
using ByteFarm.SamplerTools.Midi.SysEx.Akai.Z;
using ByteFarm.SamplerTools.Midi.SysEx.Common;
using Commons.Music.Midi;
using NUnit.Framework;

namespace ByteFarm.SamplerTools.Midi.Core
{
    [TestFixture]
    public class Experimentation
    {
        [Test]
        public async Task TestConnect()
        {
            var api = MidiAccessManager.Default;
            var output = await api.OpenOutputAsync(api.Outputs.First(a => a.Name == "DIN 4").Id);

            byte[] msg =
            {
                SysExConstants.SysExMessageStart, AkaiConstants.AkaiManufacturerId,
                ZSysExConstants.ZMPC4000DeviceTypeId, 0x0, SysExConstants.SysExMessageEnd
            };

            output.Send(msg, 0, msg.Length, 0);
        }
    }
}