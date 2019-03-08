using System;
using System.Linq;
using Commons.Music.Midi;

namespace ByteFarm.SamplerTools.Midi.Core
{
    public class Class1
    {
        public void scratch()
        {
            var connection =  MidiAccessManager.Default.OpenInputAsync("1").Result;

            
        }
    }
}
