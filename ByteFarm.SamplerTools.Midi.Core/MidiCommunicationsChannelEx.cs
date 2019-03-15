using System;
using System.Collections.Generic;
using System.Text;
using ByteFarm.SamplerTools.Midi.Core.Messages;

namespace ByteFarm.SamplerTools.Midi.Core
{
    public static class MidiCommunicationsChannelEx
    {
        public static void NoteOn(this MidiCommunicationChannel self, int channel, int key, int velocity)
        {
            self.SendMidiMessage(ChannelVoiceMessage.NoteOn(channel, key, velocity));
        }

        public static void NoteOff(this MidiCommunicationChannel self, int channel, int key, int velocity)
        {
            self.SendMidiMessage(ChannelVoiceMessage.NoteOff(channel, key, velocity));
        }

        public static void ControllerChange(this MidiCommunicationChannel self, int channel, int cc, int value)
        {
            self.SendMidiMessage(ChannelVoiceMessage.ControllerChange(channel, cc, value));
        }

        public static void PolyphonicPressure(this MidiCommunicationChannel self, int channel, int key, int pressure)
        {
            self.SendMidiMessage(ChannelVoiceMessage.PolyphonicKeyPressure(channel, key, pressure));
        }

        public static void ProgramChange(this MidiCommunicationChannel self, int channel, int program)
        {
            self.SendMidiMessage(ChannelVoiceMessage.ProgramChange(channel, program));
        }

        public static void NoteOn(this MidiCommunicationChannel self, int channel, int bend)
        {
            self.SendMidiMessage(ChannelVoiceMessage.PitchBend(channel, bend));
        }

    }
}
