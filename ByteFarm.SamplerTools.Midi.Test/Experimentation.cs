﻿using System.Linq;
using System.Threading.Tasks;
using ByteFarm.SamplerTools.Midi.SysEx.Akai;
using ByteFarm.SamplerTools.Midi.SysEx.Akai.SXL;
using ByteFarm.SamplerTools.Midi.SysEx.Akai.Z;
using ByteFarm.SamplerTools.Midi.SysEx.Common;
using Commons.Music.Midi;
using NUnit.Framework;
using Tests;

namespace ByteFarm.SamplerTools.Midi.Core
{
    [TestFixture]
    public class Experimentation
    {
        [Test]
        public async Task TestConnect()
        {
            var api = MidiAccessManager.Default;
            var output = await api.OpenOutputAsync(api.Outputs.First(a => a.Name == TestConstants.S1100PortOutput).Id);

            var msg = new SXLStatusMessage(0).FormatToMidiBytes();

            output.Send(msg, 0, msg.Length, 0);
        }
    }
}