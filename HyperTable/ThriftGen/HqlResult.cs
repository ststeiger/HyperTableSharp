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
  public partial class HqlResult : TBase
  {
    private List<string> _results;
    private List<Hypertable.ThriftGen.Cell> _cells;
    private long _scanner;
    private long _mutator;

    public List<string> Results
    {
      get
      {
        return _results;
      }
      set
      {
        __isset.results = true;
        this._results = value;
      }
    }

    public List<Hypertable.ThriftGen.Cell> Cells
    {
      get
      {
        return _cells;
      }
      set
      {
        __isset.cells = true;
        this._cells = value;
      }
    }

    public long Scanner
    {
      get
      {
        return _scanner;
      }
      set
      {
        __isset.scanner = true;
        this._scanner = value;
      }
    }

    public long Mutator
    {
      get
      {
        return _mutator;
      }
      set
      {
        __isset.mutator = true;
        this._mutator = value;
      }
    }


    public Isset __isset;
    [Serializable]
    public struct Isset {
      public bool results;
      public bool cells;
      public bool scanner;
      public bool mutator;
    }

    public HqlResult() {
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
            if (field.Type == TType.List) {
              {
                Results = new List<string>();
                TList _list0 = iprot.ReadListBegin();
                for( int _i1 = 0; _i1 < _list0.Count; ++_i1)
                {
                  string _elem2 = null;
                  _elem2 = iprot.ReadString();
                  Results.Add(_elem2);
                }
                iprot.ReadListEnd();
              }
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 2:
            if (field.Type == TType.List) {
              {
                Cells = new List<Hypertable.ThriftGen.Cell>();
                TList _list3 = iprot.ReadListBegin();
                for( int _i4 = 0; _i4 < _list3.Count; ++_i4)
                {
                  Hypertable.ThriftGen.Cell _elem5 = new Hypertable.ThriftGen.Cell();
                  _elem5 = new Hypertable.ThriftGen.Cell();
                  _elem5.Read(iprot);
                  Cells.Add(_elem5);
                }
                iprot.ReadListEnd();
              }
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 3:
            if (field.Type == TType.I64) {
              Scanner = iprot.ReadI64();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 4:
            if (field.Type == TType.I64) {
              Mutator = iprot.ReadI64();
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
      TStruct struc = new TStruct("HqlResult");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (Results != null && __isset.results) {
        field.Name = "results";
        field.Type = TType.List;
        field.ID = 1;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteListBegin(new TList(TType.String, Results.Count));
          foreach (string _iter6 in Results)
          {
            oprot.WriteString(_iter6);
          }
          oprot.WriteListEnd();
        }
        oprot.WriteFieldEnd();
      }
      if (Cells != null && __isset.cells) {
        field.Name = "cells";
        field.Type = TType.List;
        field.ID = 2;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteListBegin(new TList(TType.Struct, Cells.Count));
          foreach (Hypertable.ThriftGen.Cell _iter7 in Cells)
          {
            _iter7.Write(oprot);
          }
          oprot.WriteListEnd();
        }
        oprot.WriteFieldEnd();
      }
      if (__isset.scanner) {
        field.Name = "scanner";
        field.Type = TType.I64;
        field.ID = 3;
        oprot.WriteFieldBegin(field);
        oprot.WriteI64(Scanner);
        oprot.WriteFieldEnd();
      }
      if (__isset.mutator) {
        field.Name = "mutator";
        field.Type = TType.I64;
        field.ID = 4;
        oprot.WriteFieldBegin(field);
        oprot.WriteI64(Mutator);
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("HqlResult(");
      sb.Append("Results: ");
      sb.Append(Results);
      sb.Append(",Cells: ");
      sb.Append(Cells);
      sb.Append(",Scanner: ");
      sb.Append(Scanner);
      sb.Append(",Mutator: ");
      sb.Append(Mutator);
      sb.Append(")");
      return sb.ToString();
    }

  }

}
