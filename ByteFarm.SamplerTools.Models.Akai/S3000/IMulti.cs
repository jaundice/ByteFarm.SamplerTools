using System.Collections.Generic;

namespace ByteFarm.SamplerTools.Models.Akai.S3000
{
    public interface IMulti
    {
        IList<IProgram> Programs { get; }
    }
}