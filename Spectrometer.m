%NET.addAssembly('C:\Users\sunsh\source\repos\Spectrometer\Spectrometer\bin\Debug\Spectrometer.dll');
asm = NET.addAssembly('C:\Users\sunsh\source\repos\Spectrometer\Spectrometer\bin\x64\Debug\Spectrometer.dll');
asm.Classes
%NET.addAssembly('C:\Program Files (x86)\Microsoft.NET\Primary Interop Assemblies\Thorlabs.ccs.interop.dll');
instance = Spectrometer.Detect()
instance.getPorts()