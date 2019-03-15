namespace ByteFarm.SamplerTools.Midi.Core
{
    public class ParsedResponse
    {
        private bool SuccessfullyParsed { get; }
        private IMidiResponse Response { get; }

        public ParsedResponse(bool success, IMidiResponse response)
        {
            SuccessfullyParsed = success;
            Response = response;
        }
    }
}
