using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Thorlabs.ccs.interop64
{
	public class TLCCS : IDisposable
	{
		private class PInvoke
		{
			[DllImport("TLCCS_64.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "tlccs_init")]
			public static extern int init(string Resource_Name, ushort ID_Query, ushort Reset_Device, out IntPtr Instrument_Handle);

			[DllImport("TLCCS_64.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "tlccs_setIntegrationTime")]
			public static extern int setIntegrationTime(HandleRef Instrument_Handle, double Integration_Time__s_);

			[DllImport("TLCCS_64.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "tlccs_getIntegrationTime")]
			public static extern int getIntegrationTime(HandleRef Instrument_Handle, out double Integration_Time__s_);

			[DllImport("TLCCS_64.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "tlccs_startScan")]
			public static extern int startScan(HandleRef Instrument_Handle);

			[DllImport("TLCCS_64.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "tlccs_startScanCont")]
			public static extern int startScanCont(HandleRef Instrument_Handle);

			[DllImport("TLCCS_64.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "tlccs_startScanExtTrg")]
			public static extern int startScanExtTrg(HandleRef Instrument_Handle);

			[DllImport("TLCCS_64.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "tlccs_startScanContExtTrg")]
			public static extern int startScanContExtTrg(HandleRef Instrument_Handle);

			[DllImport("TLCCS_64.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "tlccs_getDeviceStatus")]
			public static extern int getDeviceStatus(HandleRef Instrument_Handle, out int Device_Status);

			[DllImport("TLCCS_64.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "tlccs_getScanData")]
			public static extern int getScanData(HandleRef Instrument_Handle, [In] [Out] double[] Data);

			[DllImport("TLCCS_64.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "tlccs_getRawScanData")]
			public static extern int getRawScanData(HandleRef Instrument_Handle, [In] [Out] int[] Scan_Data_Array);

			[DllImport("TLCCS_64.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "tlccs_setWavelengthData")]
			public static extern int setWavelengthData(HandleRef Instrument_Handle, [In] [Out] int[] Pixel_Data_Array, [In] [Out] double[] Wavelength_Data_Array, int Buffer_Length);

			[DllImport("TLCCS_64.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "tlccs_getWavelengthData")]
			public static extern int getWavelengthData(HandleRef Instrument_Handle, short Data_Set, [In] [Out] double[] Wavelength_Data_Array, out double Minimum_Wavelength, out double Maximum_Wavelength);

			[DllImport("TLCCS_64.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "tlccs_getUserCalibrationPoints")]
			public static extern int getUserCalibrationPoints(HandleRef Instrument_Handle, [In] [Out] int[] Pixel_Data_Array, [In] [Out] double[] Wavelength_Data_Array, out int Buffer_Length);

			[DllImport("TLCCS_64.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "tlccs_setAmplitudeData")]
			public static extern int setAmplitudeData(HandleRef Instrument_Handle, [In] [Out] double[] Amplitude_Correction_Factors, int Buffer_Length, int Buffer_Start, int Mode);

			[DllImport("TLCCS_64.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "tlccs_getAmplitudeData")]
			public static extern int getAmplitudeData(HandleRef Instrument_Handle, [In] [Out] double[] Amplitude_Correction_Factors, int Buffer_Start, int Buffer_Length, int Mode);

			[DllImport("TLCCS_64.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "tlccs_identificationQuery")]
			public static extern int identificationQuery(HandleRef Instrument_Handle, StringBuilder Manufacturer_Name, StringBuilder Device_Name, StringBuilder Serial_Number, StringBuilder Firmware_Revision, StringBuilder Instrument_Driver_Revision);

			[DllImport("TLCCS_64.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "tlccs_revisionQuery")]
			public static extern int revisionQuery(HandleRef Instrument_Handle, StringBuilder Instrument_Driver_Revision, StringBuilder Firmware_Revision);

			[DllImport("TLCCS_64.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "tlccs_reset")]
			public static extern int reset(HandleRef Instrument_Handle);

			[DllImport("TLCCS_64.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "tlccs_selfTest")]
			public static extern int selfTest(HandleRef Instrument_Handle, out short Self_Test_Result, StringBuilder Self_Test_Message);

			[DllImport("TLCCS_64.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "tlccs_errorQuery")]
			public static extern int errorQuery(HandleRef Instrument_Handle, out int Error_Number, StringBuilder Error_Message);

			[DllImport("TLCCS_64.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "tlccs_setUserText")]
			public static extern int setUserText(HandleRef Instrument_Handle, string User_Text);

			[DllImport("TLCCS_64.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "tlccs_getUserText")]
			public static extern int getUserText(HandleRef Instrument_Handle, StringBuilder User_Text);

			[DllImport("TLCCS_64.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "tlccs_close")]
			public static extern int close(HandleRef Instrument_Handle);

			[DllImport("TLCCS_64.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "tlccs_error_message")]
			public static extern int errorMessage(HandleRef Instrument_Handle, int Status_Code, StringBuilder Description);

			[DllImport("TLCCS_64.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "tlccs_getAttribute")]
			public static extern int getAttribute(HandleRef Instrument_Handle, int Attribute, out int Value);

			[DllImport("TLCCS_64.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "tlccs_setAttribute")]
			public static extern int setAttribute(HandleRef Instrument_Handle, int Attribute, int Value);

			public static int TestForError(HandleRef handle, int status)
			{
				if (status < 0)
				{
					ThrowError(handle, status);
				}
				return status;
			}

			public static int ThrowError(HandleRef handle, int code)
			{
				StringBuilder stringBuilder = new StringBuilder(256);
				errorMessage(handle, code, stringBuilder);
				throw new ExternalException(stringBuilder.ToString(), code);
			}
		}

		private HandleRef _handle;

		private bool _disposed = true;

		public IntPtr Handle => _handle.Handle;

		~TLCCS()
		{
			Dispose(disposing: false);
		}

		public TLCCS(IntPtr Instrument_Handle)
		{
			_handle = new HandleRef(this, Instrument_Handle);
			_disposed = false;
		}

		public TLCCS(string Resource_Name, bool ID_Query, bool Reset_Device)
		{
			IntPtr Instrument_Handle;
			int status = PInvoke.init(Resource_Name, Convert.ToUInt16(ID_Query), Convert.ToUInt16(Reset_Device), out Instrument_Handle);
			_handle = new HandleRef(this, Instrument_Handle);
			PInvoke.TestForError(_handle, status);
			_disposed = false;
		}

		public int setIntegrationTime(double Integration_Time__s_)
		{
			int num = PInvoke.setIntegrationTime(_handle, Integration_Time__s_);
			PInvoke.TestForError(_handle, num);
			return num;
		}

		public int getIntegrationTime(out double Integration_Time__s_)
		{
			int integrationTime = PInvoke.getIntegrationTime(_handle, out Integration_Time__s_);
			PInvoke.TestForError(_handle, integrationTime);
			return integrationTime;
		}

		public int startScan()
		{
			int num = PInvoke.startScan(_handle);
			PInvoke.TestForError(_handle, num);
			return num;
		}

		public int startScanCont()
		{
			int num = PInvoke.startScanCont(_handle);
			PInvoke.TestForError(_handle, num);
			return num;
		}

		public int startScanExtTrg()
		{
			int num = PInvoke.startScanExtTrg(_handle);
			PInvoke.TestForError(_handle, num);
			return num;
		}

		public int startScanContExtTrg()
		{
			int num = PInvoke.startScanContExtTrg(_handle);
			PInvoke.TestForError(_handle, num);
			return num;
		}

		public int getDeviceStatus(out int Device_Status)
		{
			int deviceStatus = PInvoke.getDeviceStatus(_handle, out Device_Status);
			PInvoke.TestForError(_handle, deviceStatus);
			return deviceStatus;
		}

		public int getScanData(double[] Data)
		{
			int scanData = PInvoke.getScanData(_handle, Data);
			PInvoke.TestForError(_handle, scanData);
			return scanData;
		}

		public int getRawScanData(int[] Scan_Data_Array)
		{
			int rawScanData = PInvoke.getRawScanData(_handle, Scan_Data_Array);
			PInvoke.TestForError(_handle, rawScanData);
			return rawScanData;
		}

		public int setWavelengthData(int[] Pixel_Data_Array, double[] Wavelength_Data_Array, int Buffer_Length)
		{
			int num = PInvoke.setWavelengthData(_handle, Pixel_Data_Array, Wavelength_Data_Array, Buffer_Length);
			PInvoke.TestForError(_handle, num);
			return num;
		}

		public int getWavelengthData(short Data_Set, double[] Wavelength_Data_Array, out double Minimum_Wavelength, out double Maximum_Wavelength)
		{
			int wavelengthData = PInvoke.getWavelengthData(_handle, Data_Set, Wavelength_Data_Array, out Minimum_Wavelength, out Maximum_Wavelength);
			PInvoke.TestForError(_handle, wavelengthData);
			return wavelengthData;
		}

		public int getUserCalibrationPoints(int[] Pixel_Data_Array, double[] Wavelength_Data_Array, out int Buffer_Length)
		{
			int userCalibrationPoints = PInvoke.getUserCalibrationPoints(_handle, Pixel_Data_Array, Wavelength_Data_Array, out Buffer_Length);
			PInvoke.TestForError(_handle, userCalibrationPoints);
			return userCalibrationPoints;
		}

		public int setAmplitudeData(double[] Amplitude_Correction_Factors, int Buffer_Length, int Buffer_Start, int Mode)
		{
			int num = PInvoke.setAmplitudeData(_handle, Amplitude_Correction_Factors, Buffer_Length, Buffer_Start, Mode);
			PInvoke.TestForError(_handle, num);
			return num;
		}

		public int getAmplitudeData(double[] Amplitude_Correction_Factors, int Buffer_Start, int Buffer_Length, int Mode)
		{
			int amplitudeData = PInvoke.getAmplitudeData(_handle, Amplitude_Correction_Factors, Buffer_Start, Buffer_Length, Mode);
			PInvoke.TestForError(_handle, amplitudeData);
			return amplitudeData;
		}

		public int identificationQuery(StringBuilder Manufacturer_Name, StringBuilder Device_Name, StringBuilder Serial_Number, StringBuilder Firmware_Revision, StringBuilder Instrument_Driver_Revision)
		{
			int num = PInvoke.identificationQuery(_handle, Manufacturer_Name, Device_Name, Serial_Number, Firmware_Revision, Instrument_Driver_Revision);
			PInvoke.TestForError(_handle, num);
			return num;
		}

		public int revisionQuery(StringBuilder Instrument_Driver_Revision, StringBuilder Firmware_Revision)
		{
			int num = PInvoke.revisionQuery(_handle, Instrument_Driver_Revision, Firmware_Revision);
			PInvoke.TestForError(_handle, num);
			return num;
		}

		public int reset()
		{
			int num = PInvoke.reset(_handle);
			PInvoke.TestForError(_handle, num);
			return num;
		}

		public int selfTest(out short Self_Test_Result, StringBuilder Self_Test_Message)
		{
			int num = PInvoke.selfTest(_handle, out Self_Test_Result, Self_Test_Message);
			PInvoke.TestForError(_handle, num);
			return num;
		}

		public int errorQuery(out int Error_Number, StringBuilder Error_Message)
		{
			int num = PInvoke.errorQuery(_handle, out Error_Number, Error_Message);
			PInvoke.TestForError(_handle, num);
			return num;
		}

		public int setUserText(string User_Text)
		{
			int num = PInvoke.setUserText(_handle, User_Text);
			PInvoke.TestForError(_handle, num);
			return num;
		}

		public int getUserText(StringBuilder User_Text)
		{
			int userText = PInvoke.getUserText(_handle, User_Text);
			PInvoke.TestForError(_handle, userText);
			return userText;
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		private void Dispose(bool disposing)
		{
			if (!_disposed)
			{
				PInvoke.close(_handle);
				_handle = new HandleRef(null, IntPtr.Zero);
			}
			_disposed = true;
		}
	}
}
