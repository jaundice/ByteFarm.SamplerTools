using System;
using System.Collections.Generic;
using ByteFarm.SamplerTools.Midi.Core;
using ByteFarm.SamplerTools.Midi.SysEx.Akai.S1000;
using ByteFarm.SamplerTools.Midi.SysEx.Common;

namespace ByteFarm.SamplerTools.Midi.SysEx.Akai.SXL
{
    internal class AkaiSXLResponseParser : ISysExResponseParser
    {
        private readonly Dictionary<byte, Func<byte[], IMidiResponse>> _FunctionHandlers =
            new Dictionary<byte, Func<byte[], IMidiResponse>>
            {
                {(byte) S1000FunctionCode.STAT, ParseStatusResponse}
            };

        public bool CanParse(byte[] rawData)
        {
            return rawData[0] == SysExConstants.SysExMessageStart 
                   && rawData[1] == AkaiConstants.AkaiManufacturerId 
                   && rawData[4] == SXLSysExConstants.SXLDeviceTypeId 
                   && _FunctionHandlers.ContainsKey(rawData[3]);
        }

        public ParsedResponse Parse(byte[] rawResponse)
        {
            try
            {
                return new ParsedResponse(true, _FunctionHandlers[rawResponse[3]](rawResponse));
            }
            catch
            {
                return new ParsedResponse(false, new MidiResponse(rawResponse));
            }
        }

        private static IMidiResponse ParseStatusResponse(byte[] arg)
        {
            throw new NotImplementedException();
        }
    }
}