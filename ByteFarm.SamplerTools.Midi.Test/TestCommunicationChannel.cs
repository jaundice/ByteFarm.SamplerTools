using ByteFarm.SamplerTools.Midi.Core;
using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class TestCommunicationChannel
    {
        public void TestChannel()
        {
            MidiCommunicationChannel comms = new MidiCommunicationChannel("DIN 4", "DIN 4");

            comms.MidiResponse += MidiResponse;

        }

        private void MidiResponse(object sender, MidiResponseReceivedEventArgs e)
        {
            Console.Write(e.Response.RawData);
        }
    }
}