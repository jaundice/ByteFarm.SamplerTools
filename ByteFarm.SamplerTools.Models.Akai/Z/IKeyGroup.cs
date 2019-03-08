using System.Collections.Generic;

namespace ByteFarm.SamplerTools.Models.Akai.Z
{
    public interface IKeyGroup
    {
        IList<IKeySpan> KeySpans { get; }
    }
}