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
  public partial class RowInterval : TBase
  {
    private string _start_row;
    private bool _start_inclusive;
    private string _end_row;
    private bool _end_inclusive;

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

    public bool Start_inclusive
    {
      get
      {
        return _start_inclusive;
      }
      set
      {
        __isset.start_inclusive = true;
        this._start_inclusive = value;
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

    public bool End_inclusive
    {
      get
      {
        return _end_inclusive;
      }
      set
      {
        __isset.end_inclusive = true;
        this._end_inclusive = value;
      }
    }


    public Isset __isset;
    [Serializable]
    public struct Isset {
      public bool start_row;
      public bool start_inclusive;
      public bool end_row;
      public bool end_inclusive;
    }

    public RowInterval() {
      this._start_inclusive = true;
      this._end_inclusive = true;
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
            if (field.Type == TType.Bool) {
              Start_inclusive = iprot.ReadBool();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 3:
            if (field.Type == TType.String) {
              End_row = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 4:
            if (field.Type == TType.Bool) {
              End_inclusive = iprot.ReadBool();
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
      TStruct struc = new TStruct("RowInterval");
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
      if (__isset.start_inclusive) {
        field.Name = "start_inclusive";
        field.Type = TType.Bool;
        field.ID = 2;
        oprot.WriteFieldBegin(field);
        oprot.WriteBool(Start_inclusive);
        oprot.WriteFieldEnd();
      }
      if (End_row != null && __isset.end_row) {
        field.Name = "end_row";
        field.Type = TType.String;
        field.ID = 3;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(End_row);
        oprot.WriteFieldEnd();
      }
      if (__isset.end_inclusive) {
        field.Name = "end_inclusive";
        field.Type = TType.Bool;
        field.ID = 4;
        oprot.WriteFieldBegin(field);
        oprot.WriteBool(End_inclusive);
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("RowInterval(");
      sb.Append("Start_row: ");
      sb.Append(Start_row);
      sb.Append(",Start_inclusive: ");
      sb.Append(Start_inclusive);
      sb.Append(",End_row: ");
      sb.Append(End_row);
      sb.Append(",End_inclusive: ");
      sb.Append(End_inclusive);
      sb.Append(")");
      return sb.ToString();
    }

  }

}
