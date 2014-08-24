/**
 * Autogenerated by Thrift Compiler (0.8.0)
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 *  @generated
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Thrift;
using Thrift.Collections;
using Thrift.Protocol;
using Thrift.Transport;
namespace Hypertable.ThriftGen
{

  [Serializable]
  public partial class TableSplit : TBase
  {
    private string _start_row;
    private string _end_row;
    private string _location;
    private string _ip_address;
    private string _hostname;

    public string Start_row
    {
      get
      {
        return _start_row;
      }
      set
      {
        __isset.start_row = true;
        this._start_row = value;
      }
    }

    public string End_row
    {
      get
      {
        return _end_row;
      }
      set
      {
        __isset.end_row = true;
        this._end_row = value;
      }
    }

    public string Location
    {
      get
      {
        return _location;
      }
      set
      {
        __isset.location = true;
        this._location = value;
      }
    }

    public string Ip_address
    {
      get
      {
        return _ip_address;
      }
      set
      {
        __isset.ip_address = true;
        this._ip_address = value;
      }
    }

    public string Hostname
    {
      get
      {
        return _hostname;
      }
      set
      {
        __isset.hostname = true;
        this._hostname = value;
      }
    }


    public Isset __isset;
    [Serializable]
    public struct Isset {
      public bool start_row;
      public bool end_row;
      public bool location;
      public bool ip_address;
      public bool hostname;
    }

    public TableSplit() {
    }

    public void Read (TProtocol iprot)
    {
      TField field;
      iprot.ReadStructBegin();
      while (true)
      {
        field = iprot.ReadFieldBegin();
        if (field.Type == TType.Stop) { 
          break;
        }
        switch (field.ID)
        {
          case 1:
            if (field.Type == TType.String) {
              Start_row = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 2:
            if (field.Type == TType.String) {
              End_row = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 3:
            if (field.Type == TType.String) {
              Location = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 4:
            if (field.Type == TType.String) {
              Ip_address = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 5:
            if (field.Type == TType.String) {
              Hostname = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          default: 
            TProtocolUtil.Skip(iprot, field.Type);
            break;
        }
        iprot.ReadFieldEnd();
      }
      iprot.ReadStructEnd();
    }

    public void Write(TProtocol oprot) {
      TStruct struc = new TStruct("TableSplit");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (Start_row != null && __isset.start_row) {
        field.Name = "start_row";
        field.Type = TType.String;
        field.ID = 1;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(Start_row);
        oprot.WriteFieldEnd();
      }
      if (End_row != null && __isset.end_row) {
        field.Name = "end_row";
        field.Type = TType.String;
        field.ID = 2;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(End_row);
        oprot.WriteFieldEnd();
      }
      if (Location != null && __isset.location) {
        field.Name = "location";
        field.Type = TType.String;
        field.ID = 3;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(Location);
        oprot.WriteFieldEnd();
      }
      if (Ip_address != null && __isset.ip_address) {
        field.Name = "ip_address";
        field.Type = TType.String;
        field.ID = 4;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(Ip_address);
        oprot.WriteFieldEnd();
      }
      if (Hostname != null && __isset.hostname) {
        field.Name = "hostname";
        field.Type = TType.String;
        field.ID = 5;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(Hostname);
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("TableSplit(");
      sb.Append("Start_row: ");
      sb.Append(Start_row);
      sb.Append(",End_row: ");
      sb.Append(End_row);
      sb.Append(",Location: ");
      sb.Append(Location);
      sb.Append(",Ip_address: ");
      sb.Append(Ip_address);
      sb.Append(",Hostname: ");
      sb.Append(Hostname);
      sb.Append(")");
      return sb.ToString();
    }

  }

}