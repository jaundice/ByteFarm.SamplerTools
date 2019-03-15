namespace ByteFarm.SamplerTools.Midi.Core
{
    public interface ISysExResponseParser
    {
        bool CanParse(byte[] rawData);
        ParsedResponse Parse(byte[] rawResponse);
    }
}
