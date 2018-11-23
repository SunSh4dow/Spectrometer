using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Ports;
using Thorlabs.ccs.interop64;

namespace Spectrometer
{
    public class Detect
    {
        string usedPort = "COM16";
        
        public string[] getPorts()
        {
            string[] ports = SerialPort.GetPortNames();
            return ports;
        }

        public void setPort(string s)
        {
            usedPort = s;
        }

        public double[] Test(int l)
        {
            double[] Test = new double[3648];
            System.Random random = new System.Random();
            for (int i=0; i<3648; i++)
            {
                Test[i] = random.NextDouble();
            }
            return Test;//
        }
        
        // takes LED Number, returns noise reduced spectrometer data
        public double[] getData(int i)
        {
            // initialize spectrometer
            TLCCS ccsSeries = new TLCCS("USB0::0x1313::0x8089::M" + 00264713 + "::RAW", false, false); // S/N M00264713

            int status;
            int res = ccsSeries.getDeviceStatus(out status);

            // open COM-Port to access LEDs
            SerialPort sp = new SerialPort(usedPort);
            sp.BaudRate = 115200;
            sp.DataBits = 8;
            sp.Parity = Parity.None;
            sp.StopBits = StopBits.One;
            sp.Handshake = Handshake.None;
            sp.DtrEnable = true;
            sp.RtsEnable = true;
            sp.Open();

            res = ccsSeries.setIntegrationTime(0.1); // 100ms
            res = ccsSeries.startScan(); // single scan
            do
            {
                res = ccsSeries.getDeviceStatus(out status);
            } while ((status & 0x0010) == 0); // wait for scan to finish
            double[] dataNoise = new double[3648];
            res = ccsSeries.getScanData(dataNoise); // save data into double dataNoise

            // second scan for actual information
            sp.Write(new byte[] { (byte)(1 << i) }, 0, 1); // LED on / next LED
            System.Threading.Thread.Sleep(20); // wait for LED
            res = ccsSeries.startScan(); // single scan
            do
            {
                res = ccsSeries.getDeviceStatus(out status);
            } while ((status & 0x0010) == 0); // wait for scan
            double[] dataLED = new double[3648];
            res = ccsSeries.getScanData(dataLED);

            // remove noise, save data into dataLED
            for (int j = 0; j < dataLED.Length; j++)
            {
                if ((dataLED[j] = dataLED[j] - dataNoise[j]) > 0)
                {
                    dataLED[j] = dataLED[j] - dataNoise[j];
                }
                else
                {
                    dataLED[j] = 0;
                }
            }
            ccsSeries.Dispose();  // deinitialize spectrometer
            sp.Close();  // close port
            return dataLED;
        }
    }
}
