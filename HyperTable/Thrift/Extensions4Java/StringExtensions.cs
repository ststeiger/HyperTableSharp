/**
 * Copyright (C) 2014 Stefan Steiger
 *
 * This file is distributed under the Apache Software License
 * (http://www.apache.org/licenses/)
 */

// http://stackoverflow.com/questions/11654562/how-convert-byte-array-to-string
// http://stackoverflow.com/questions/472906/converting-a-string-to-byte-array
namespace Hypertable.Thrift
{


	internal static class StringExtensions
	{


		/*
		public static bool equals(this string str, string str2)
		{
			return str.Equals (str2);
		}
		*/

		internal static void printStackTrace(this System.Exception ex)
		{
			System.Console.Error.WriteLine (ex.StackTrace);
		}

		internal static byte[] getBytes(this string str)
		{
			byte[] bytes = new byte[str.Length * sizeof(char)];
			System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
			return bytes;
		}


		internal static byte[] GetBytes(this string str)
		{
			byte[] bytes = new byte[str.Length * sizeof(char)];
			System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
			return bytes;
		}

        // Hypertable.Thrift.StringExtensions.GetString
		internal static string GetString(byte[] bytes)
		{
			char[] chars = new char[bytes.Length / sizeof(char)];
			System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
			return new string(chars);
		}


	}


}
