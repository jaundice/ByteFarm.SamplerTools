using System.Collections.Generic;

namespace ByteFarm.SamplerTools.Models.Akai.S3000
{
    public interface IProgram
    {
        IKeyRange KeyRange { get; set; }
        ushort ProgramNumber { get; set; }
        NotePriority NotePriority { get; set; }
        MidiChannel MidiChannel { get; set; }
        Tuning Tuning { get; set; }
        IFxRouting FxRouting { get; set; }
        IAudioOutput AudioOutput { get; set; }
        IndividualOutput IndividualOutput { get; set; }
        IList<IKeyGroup> KeyGroups { get; }
    }
}