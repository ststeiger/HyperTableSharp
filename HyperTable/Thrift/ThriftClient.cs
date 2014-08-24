
/**
 * Copyright (C) 2014 Stefan Steiger
 * Copyright (C) 2007-2012 Hypertable, Inc.
 *
 * This file is distributed under the Apache Software License
 * (http://www.apache.org/licenses/)
 */


// import org.hypertable.thriftgen.*;

// import org.apache.thrift.TException;
// import org.apache.thrift.transport.TSocket;
// import org.apache.thrift.transport.TFramedTransport;
// import org.apache.thrift.transport.TTransportException;
// import org.apache.thrift.protocol.TBinaryProtocol;
// import org.apache.thrift.protocol.TProtocol;


// using Thrift;
// using Thrift.Server;
// using Thrift.Protocol;
// using Thrift.Transport;

using Hypertable.ThriftGen;

using TException = Thrift.TException;
using TSocket = Thrift.Transport.TSocket;
using TFramedTransport = Thrift.Transport.TFramedTransport;
using TTransportException = Thrift.Transport.TTransportException;
using TBinaryProtocol = Thrift.Protocol.TBinaryProtocol;
using TProtocol = Thrift.Protocol.TProtocol;



// /hypertable/src/java/ThriftClient/org/hypertable/thrift/ThriftClient.java
namespace Hypertable.Thrift
{


    public class ThriftClient : HqlService.Client
    {
        public ThriftClient(TProtocol protocol)
            : base(protocol)
        { }

        /**
         * Java factory method for creating a new ThriftClient
         *
         * @param host  hostname of the ThriftBroker
         * @param port  port of the ThriftBroker
         * @param timeout  connection timeout
         * @param do_open  set to true to immediately open the connection
         * @param max_framesize  maximum thrift framesize (in bytes)
         */
        public static ThriftClient create(string host, int port, int timeout_ms,
            bool do_open, int max_framesize)
        //throws TTransportException, TException 
        {


            TFramedTransport transport = new TFramedTransport(
                new TSocket(host, port, timeout_ms)
                //,max_framesize
            );

            ThriftClient client = new ThriftClient(new TBinaryProtocol(transport));
            client.transport = transport;

            if (do_open)
                client.open();

            return client;
        }


        /**
         * Java factory method for creating a new ThriftClient
         *
         * @param host  hostname of the ThriftBroker
         * @param port  port of the ThriftBroker
         * @param timeout  connection timeout
         * @param do_open  set to true to immediately open the connection
         */
        public static ThriftClient create(string host, int port
            , int timeout_ms, bool do_open) //throws TTransportException, TException 
        {
            TFramedTransport transport = new TFramedTransport(
                new TSocket(host, port, timeout_ms));
            ThriftClient client = new ThriftClient(new TBinaryProtocol(transport));
            client.transport = transport;

            if (do_open)
                client.open();

            return client;
        }

        // Java doesn't support default argument values, which makes things
        // unnecessarily verbose here
        public static ThriftClient create(string host, int port)
        // throws TTransportException, TException 
        {
            return create(host, port, 1600000, true);
        }

        public void open() //throws TTransportException, TException 
        {
            transport.Open();
            do_close = true;
        }

        public void close()
        {
            if (do_close)
            {
                transport.Close();
                do_close = false;
            }
        }

        private TFramedTransport transport;
        private bool do_close = false;
    }


}
