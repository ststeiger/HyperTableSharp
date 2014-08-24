
using System;

using Thrift;
using Hypertable.ThriftGen;
using Thrift.Server;
using Thrift.Protocol;


using Thrift.Transport;


namespace HyperTableSharp
{


	// Problem in ThriftGen/ClientException.cs ==> Message ==> new
	// Problem in StringExtensions ==> Encoding ???
	// Problem in SerializedCellsReader.cs ==> revision, java.lang.System.arraycopy
	class MainClass
	{


		// https://groups.google.com/forum/#!topic/hypertable-dev/K3tPn6LGmRQ
		// http://wiki.apache.org/thrift/ThriftUsageCSharp
		// http://thrift.apache.org/tutorial/
		// http://damianblog.com/2011/01/11/generating-silverlight-windows-phone-compatible-thrift-proxies/
		// https://github.com/hypertable/hypertable/blob/master/src/cc/ThriftBroker/tests/client_test.cc

		// https://groups.google.com/forum/#!topic/hypertable-user/La8RoOvFZD0
		// /opt/hypertable/current/lib/java/cdh4
		// /root/sources/hypertable/hypertable/src/java
		public static void Main (string[] args)
		{
			BasicClientTest.Start ();
			Console.WriteLine ("Hello World!");

		}


	}


}
