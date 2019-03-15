using ByteFarm.SamplerTools.Midi.Core;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading;
using ByteFarm.SamplerTools.Midi.Core.Messages;
using ByteFarm.SamplerTools.Midi.SysEx.Akai;
using ByteFarm.SamplerTools.Midi.SysEx.Akai.SXL;
using ByteFarm.SamplerTools.Midi.SysEx.Akai.Z;

namespace Tests
{
    [TestFixture]
    public class TestCommunicationChannel
    {

        private string TestPort = TestConstants.S1100Port;
        private int TestMidiChannel = MidiChannel.One;


        [Test]
        public void TestNoteOnOff()
        {
            using (MidiCommunicationChannel comms =
                new MidiCommunicationChannel(TestPort, TestPort))
            {
                var msg = ChannelVoiceMessage.NoteOn(TestMidiChannel, 80, 127);

                DebugMessage(msg);

                comms.SendMidiMessage(msg);

                Thread.Sleep(2000);
                msg = ChannelVoiceMessage.NoteOff(TestMidiChannel, 80, 30);


                DebugMessage(msg);
                comms.SendMidiMessage(msg);


                comms.NoteOn(MidiChannel.One, 80, 127);

                Thread.Sleep(2000);

                comms.NoteOff(MidiChannel.One, 80, 20);
            }
        }


        [Test]
        public void TestChannel()
        {

            Console.WriteLine(string.Join(", ", MidiCommunicationChannel.AvailableMidiInputPorts.Select(a => a.Name)));

            using (MidiCommunicationChannel comms =
                new MidiCommunicationChannel(TestPort, TestPort))
            {

                comms.MidiResponse += MidiResponse;
                Console.WriteLine("Sending Message");

                var status = new SXLStatusMessage(0);

                DebugMessage(status);

                comms.SendMidiMessage(status, a => Console.Write("made it back"));

                Thread.Sleep(200);





                Console.WriteLine("Response");
                Console.WriteLine(response == null ? "No Response" : string.Join("", response.RawData.Select(a => a.ToString("x2"))));

                if (response != null)
                {
                    var parsed = new AkaiSysExResponseParser().Parse(response.RawData);
                }

                //comms.SendMidiMessage(new ZStatusMessage(0));
                //comms.SendMidiMessage(new RawMidiMessage(new byte[] { 0xF0, 0x47, 0x1, 0x0, 0x48, 0xF7 }, 0, 0));

            }
        }

        private void DebugMessage(IMidiMessage msg)
        {
            var bytes = msg.FormatToMidiBytes();

            Console.WriteLine(string.Join("", bytes.Select(a => a.ToString("x2"))));
        }

        private IMidiResponse response = null;


        private void MidiResponse(object sender, MidiResponseReceivedEventArgs e)
        {

            response = e.Response;
        }
    }
}