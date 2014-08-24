/**
 * Copyright (C) 2014 Stefan Steiger
 * Copyright (C) 2007-2012 Hypertable, Inc.
 *
 * This file is distributed under the Apache Software License
 * (http://www.apache.org/licenses/)
 */


using Thrift;
using Thrift.Server;
using Thrift.Protocol;
using Thrift.Transport;

using Hypertable.ThriftGen;


// /hypertable/src/java/ThriftClient/org/hypertable/thrift/SerializedCellsFlag.java

// http://stackoverflow.com/questions/1327544/what-is-the-equivalent-of-javas-final-in-c
namespace Hypertable.Thrift
{


    public class SerializedCellsFlag
    {

        public static readonly byte EOB = (byte)0x01;
        public static readonly byte EOS = (byte)0x02;
        public static readonly byte FLUSH = (byte)0x04;
        public static readonly byte REV_IS_TS = (byte)0x10;
        public static readonly byte AUTO_TIMESTAMP = (byte)0x20;
        public static readonly byte HAVE_TIMESTAMP = (byte)0x40;
        public static readonly byte HAVE_REVISION = (byte)0x80;

        public static readonly byte FLAG_DELETE_ROW = (byte)0x00;
        public static readonly byte FLAG_DELETE_COLUMN_FAMILY = (byte)0x01;
        public static readonly byte FLAG_DELETE_CELL = (byte)0x02;
        public static readonly byte FLAG_INSERT = (byte)0xFF;

        public static readonly long NULL = long.MinValue + 1; //   Long.MIN_VALUE + 1;
        public static readonly long AUTO_ASSIGN = long.MinValue + 2; // Long.MIN_VALUE + 2;

        public static readonly byte VERSION = (byte)0x01;

    }


}
