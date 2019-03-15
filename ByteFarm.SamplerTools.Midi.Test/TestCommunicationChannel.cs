using ByteFarm.SamplerTools.Midi.Core;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading;
using ByteFarm.SamplerTools.Midi.Core.Messages;
using ByteFarm.SamplerTools.Midi.SysEx.Akai.SXL;
using ByteFarm.SamplerTools.Midi.SysEx.Akai.Z;

namespace Tests
{
    [TestFixture]
    public class TestCommunicationChannel
    {
        [Test]
        public void TestChannel()
        {

            Console.WriteLine(string.Join(", ", MidiCommunicationChannel.AvailableMidiInputPorts.Select(a => a.Name)));

            using (MidiCommunicationChannel comms =
                new MidiCommunicationChannel("DIN 1", "DIN 1"))
            {

                comms.MidiResponse += MidiResponse;
                Console.WriteLine("Sending Message");
               // comms.SendMidiMessage(new SXLStatusMessage(0));

                Thread.Sleep(200);
                var msg = ChannelVoiceMessage.NoteOn(MidiChannel.One, 80, 127);

                DebugMessage(msg);

                comms.SendMidiMessage(msg);

                Thread.Sleep(2000);
                msg = ChannelVoiceMessage.NoteOff(MidiChannel.One, 80, 30);


                DebugMessage(msg);
                comms.SendMidiMessage(msg);


                comms.NoteOn(MidiChannel.One, 80, 127);

                Thread.Sleep(2000);

                comms.NoteOff(MidiChannel.One, 80, 20);

                //comms.SendMidiMessage(new ZStatusMessage(0));
                //comms.SendMidiMessage(new RawMidiMessage(new byte[] { 0xF0, 0x47, 0x1, 0x0, 0x48, 0xF7 }, 0, 0));

                Thread.Sleep(5000);
            }
        }

        private void DebugMessage(IMidiMessage msg)
        {
            var bytes = msg.FormatToMidiBytes();

            Console.WriteLine(string.Join("", bytes.Select(a => a.ToString("x"))));
        }

        private void MidiResponse(object sender, MidiResponseReceivedEventArgs e)
        {
            Console.Write("Response Received");
            Console.Write(e.Response.RawData);
        }
    }
}