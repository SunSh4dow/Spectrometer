NET.addAssembly('C:\Users\sunsh\source\repos\Spectrometer\Spectrometer\bin\x64\Debug\Spectrometer.dll');
instance = Spectrometer.Detect();
x = 'flower';
raw = instance.Test(1);
spectrum = double(raw);
ds = datastore










% for i=1:8
%     raw = instance.Test(i);
%     spectrum = double(raw);
%     save(x,'spectrum','-append');
% end
% stored = load('flower.mat');




% dat = instance.Test();
% data = double(dat);
% save('test','data')
% dat2 = instance.Test();
% data2 = double(dat2);
% save('test','data2', '-append');
% load('test.mat');
% plot (data)

