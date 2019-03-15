using System;
using System.Collections.Generic;
using System.Text;
using ByteFarm.SamplerTools.Midi.Core;
using ByteFarm.SamplerTools.Midi.SysEx.Akai.SXL;
using ByteFarm.SamplerTools.Midi.SysEx.Common;

namespace ByteFarm.SamplerTools.Midi.SysEx.Akai
{
    public class AkaiSysExResponseParser : ISysExResponseParser
    {
        private readonly Dictionary<byte, ISysExResponseParser> _DeviceSpecificParsers =
            new Dictionary<byte, ISysExResponseParser>
            {
                {SXLSysExConstants.SXLDeviceTypeId, new AkaiSXLResponseParser() }
            };

        public virtual bool CanParse(byte[] rawData)
        {
            return rawData[0] == SysExConstants.SysExMessageStart && rawData[1] == AkaiConstants.AkaiManufacturerId &&
                   _DeviceSpecificParsers.ContainsKey(rawData[4]) &&
                   _DeviceSpecificParsers[rawData[4]].CanParse(rawData);
        }

        public ParsedResponse Parse(byte[] rawResponse)
        {
            if(!CanParse(rawResponse))
                return new ParsedResponse(false, new MidiResponse(rawResponse));

            return _DeviceSpecificParsers[rawResponse[4]].Parse(rawResponse);
        }

    }
}
