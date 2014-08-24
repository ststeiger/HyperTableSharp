/**
 * Copyright (C) 2014 Stefan Steiger
 *
 * This file is distributed under the Apache Software License
 * (http://www.apache.org/licenses/)
 */


namespace HyperTableSharp 
{


	internal static class StringExtensions
	{

		internal static byte[] getBytes(this string str)
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


		internal static string GetValue(this Hypertable.ThriftGen.Cell cell)
		{
			return GetString(cell.Value);
		}


		internal static void SetValue(this Hypertable.ThriftGen.Cell cell, string vtmp)
		{
			cell.Value = getBytes(vtmp);
		}


	} // End Class


} // End Namespace
