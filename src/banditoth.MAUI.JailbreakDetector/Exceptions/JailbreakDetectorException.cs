using System;
namespace banditoth.MAUI.JailbreakDetector.Exceptions
{
	public class JailbreakDetectorException : Exception
	{
		public JailbreakDetectorException(Exception ex) :
			base("Could not check the device's Jailbreak or Root status. See inner exceptions for further details",
			ex)
		{

		}
	}
}

