﻿using ByteFarm.SamplerTools.Midi.Core;
using System;
using System.IO;

namespace ByteFarm.SamplerTools.Midi.SysEx.Common
{
    public abstract class StatusMessageBase : IMidiMessage
    {
        public byte ManufacturerId { get; }

        public byte DeviceTypeId { get; }

        public byte UniqueDeviceId { get; }

        public int Offset => 0;
        public int Length => 0;

        protected StatusMessageBase(byte manufacturerId, byte deviceTypeId, byte uniqueDeviceId)
        {
            ManufacturerId = manufacturerId;
            DeviceTypeId = deviceTypeId;
            UniqueDeviceId = uniqueDeviceId;
        }

        public abstract byte[] FormatToMidiBytes();
    }
}