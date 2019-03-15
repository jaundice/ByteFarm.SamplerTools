using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ByteFarm.SamplerTools.Midi.Core.Messages
{
    public class ChannelVoiceMessage : IMidiVoiceMessage
    {
        private const byte DataMask = 127;


        public static ChannelVoiceMessage NoteOn(int channel, int key, int velocity)
        {
            return new ChannelVoiceMessage(ChannelVoiceMessageType.NoteOn, (byte)channel, (byte)key, (byte)velocity);
        }

        public static ChannelVoiceMessage NoteOff(int channel, int key, int velocity)
        {
            return new ChannelVoiceMessage(ChannelVoiceMessageType.NoteOff, (byte)channel, (byte)key, (byte)velocity);
        }

        public static ChannelVoiceMessage PolyphonicKeyPressure(int channel, int key, int pressure)
        {
            return new ChannelVoiceMessage(ChannelVoiceMessageType.PolyphonicKeyPressure, (byte)channel, (byte)key, (byte)pressure);
        }

        public static ChannelVoiceMessage ControllerChange(int channel, int controllerCC, int value)
        {
            return new ChannelVoiceMessage(ChannelVoiceMessageType.ControlChange, (byte)channel, (byte)controllerCC, (byte)value);
        }

        public static ChannelVoiceMessage ProgramChange(int channel, int programNumber)
        {
            return new ChannelVoiceMessage(ChannelVoiceMessageType.ProgramChange, (byte)channel, (byte)programNumber);
        }

        public static ChannelVoiceMessage PitchBend(int channel, int bend)
        {
            byte b1, b2;
            b1 = b2 = 0;

            throw new NotImplementedException();

            return new ChannelVoiceMessage(ChannelVoiceMessageType.PitchBend, (byte)channel, b1, b2);
        }

        public ChannelVoiceMessage(ChannelVoiceMessageType messageType, byte channel, byte byte1, byte? byte2 = null)
        {
            MessageType = messageType;
            MidiChannel = channel;
            Byte1 = byte1;
            Byte2 = byte2;

        }

        public ChannelVoiceMessageType MessageType { get; }

        public byte[] FormatToMidiBytes()
        {
            byte statusByte = GenerateStatusByte();

            using (var mem = new MemoryStream())
            using (var br = new BinaryWriter(mem))
            {
                br.Write(statusByte);
                br.Write((byte)(Byte1 & DataMask));

                if (Byte2.HasValue)
                {
                    br.Write((byte)(Byte2.Value & DataMask));
                }

                br.Flush();
                return mem.ToArray();
            }
        }

        private byte GenerateStatusByte()
        {
            return (byte)((0x1 << 7) | (byte)((byte)MessageType << 4) | (MidiChannel));
        }

        public int Offset => 0;

        public int Length
        {
            get
            {
                switch (MessageType)
                {
                    case ChannelVoiceMessageType.ProgramChange:
                    case ChannelVoiceMessageType.ChannelPressure:
                        return 2;
                    default:
                        return 3;
                }
            }
        }

        public byte MidiChannel { get; }
        public byte Byte1 { get; }
        public byte? Byte2 { get; }
    }
}
