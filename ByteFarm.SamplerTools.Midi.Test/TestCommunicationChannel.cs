using ByteFarm.SamplerTools.Midi.Core;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class TestCommunicationChannel
    {
        public void TestChannel()
        {
            var comms = new MidiCommunicationChannel("DIN 4", "DIN 4");
        }
    }
}