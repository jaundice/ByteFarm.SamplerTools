using System;
using ByteFarm.SamplerTools.Midi.Core;

namespace ByteFarm.SamplerTools.Midi.SysEx.Common
{
    public abstract class StatusMessageBase : IMidiMessage
    {
        public abstract byte ManufacturerId { get; }

        public abstract byte DeviceTypeId { get; }

        public abstract byte UniqueDeviceId { get; }

        public byte[] FormatToMidiBytes()
        {
            throw new NotImplementedException();
        }
    }
}