# ByteFarm.SamplerTools
Beginnings of an idea to build an editor for old hardware samplers on modern computer operating systems using SysEx messages.

Initial plan is to develop a cross platform library covering Windows / OSX / Linux with:
* General midi functionality
* Akai Sysex functionality for s1100, s3000xl and z8 (samplers I own)
* E-mu EOS 4.7 sysex functionality (again samplers I own)
  
After that I plan on developing a cross platform UI with which the samplers can be controlled.

The library is being designed in such a way that other samplers can be added easily

Along the way I'll be adding object models for the sampler's storage of presets whcih I also hope to be able to use to create presets which can then be copied over to the sampler
  
