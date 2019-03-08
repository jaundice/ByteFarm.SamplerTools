using ByteFarm.SamplerTools.Midi.Core;
using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Threading;
using ByteFarm.SamplerTools.Midi.SysEx.Akai.SXL;

namespace Tests
{
    [TestFixture]
    public class TestCommunicationChannel
    {
        [Test]
        public void TestChannel()
        {
            using (MidiCommunicationChannel comms =
                new MidiCommunicationChannel(TestConstants.S1100Port, TestConstants.S1100Port))
            {

                comms.MidiResponse += MidiResponse;
                Console.WriteLine("Sending Message");
                comms.SendMidiMessage(new SXLStatusMessage(0));

                Thread.Sleep(5000);
            }
        }

        private void MidiResponse(object sender, MidiResponseReceivedEventArgs e)
        {
            Console.Write("Response Received");
            Console.Write(e.Response.RawData);
        }
    }
}