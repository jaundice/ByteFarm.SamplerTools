using System.Collections.Generic;

namespace ByteFarm.SamplerTools.Models.Akai.Z
{
    public interface IMulti
    {
        IList<IProgram> Programs { get; }
    }
}