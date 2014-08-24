/**
 * Copyright (C) 2014 Stefan Steiger
 * Copyright (C) 2007-2012 Hypertable, Inc.
 *
 * This file is distributed under the Apache Software License
 * (http://www.apache.org/licenses/)
 */

using System.Collections.Generic;

// import java.nio.ByteBuffer;
// import java.util.List;
// import java.util.HashMap;
// import java.util.Iterator;

// import org.hypertable.thriftgen.*;


using Hypertable.ThriftGen;

//using Hypertable.Thrift;
using ThriftClient = Hypertable.Thrift.ThriftClient;


//    /opt/hypertable/current/bin/start-all-servers.sh local
//   /opt/hypertable/current/bin/ht shell


namespace HyperTableSharp 
{


    public class BasicClientTest
    {


		public static void Start()
        {

            ThriftClient client = null;
            long ns = -1;

            try
            {
                client = ThriftClient.create("localhost", 38080);
                
				// if (!client.namespace_exists("Tutorial"))
				if (!client.namespace_exists("test"))
					System.Console.WriteLine("Namespace test does not exist");
					//client.namespace_create("test");

				client.create_namespace("mynamespace");


				ns = client.namespace_open("test");

                // HQL examples
                show(client.hql_query(ns, "show tables").ToString());
                show(client.hql_query(ns, "select * from thrift_test").ToString());
                // Schema example
                Schema schema = new Schema();
                schema = client.table_get_schema(ns, "thrift_test");


                /*
                Iterator ag_it = schema.access_groups.keySet().iterator();
                show("Access groups:");
                while (ag_it.hasNext()) 
                {
                show("\t" + ag_it.next());
                }
                */

                show("Access groups:");
                foreach (string ThisAccessGroup in schema.Access_groups.Keys)
                {
                    show("\t" + ThisAccessGroup);
                }


                /*
                Iterator cf_it = schema.column_families.keySet().iterator();
                show("Column families:");
                while (cf_it.hasNext()) 
                {
                    show("\t" + cf_it.next());
                }
                */

                show("Column families:");
                foreach (string ThisFamily in schema.Column_families.Keys)
                {
                    show("\t" + ThisFamily);
                }



                // mutator examples
                long mutator = client.mutator_open(ns, "thrift_test", 0, 0);

                try
                {
                    Cell cell = new Cell();
                    Key key = new Key();
                    key.Row = "java-k1";
                    key.Column_family = "col";
                    cell.Key = key;
                    string vtmp = "java-v1";
                    //// cell.Value = ByteBuffer.wrap(vtmp.getBytes() );
					cell.Value = vtmp.getBytes();
					//cell.SetValue(vtmp);

					client.mutator_set_cell(mutator, cell);
                }
                finally
                {
                    client.mutator_close(mutator);
                }

                // shared mutator example
                {
                    MutateSpec mutate_spec = new MutateSpec();
                    mutate_spec.Appname = "test-java";
                    mutate_spec.Flush_interval = 1000;
                    Cell cell = new Cell();
                    Key key;

                    key = new Key();
                    key.Row = "java-put1";
                    key.Column_family = "col";
                    cell.Key = key;

                    string vtmp = "java-put-v1";
                    //// cell.Value = ByteBuffer.wrap(vtmp.getBytes());
					cell.Value = vtmp.getBytes();
                    client.offer_cell(ns, "thrift_test", mutate_spec, cell);

                    key = new Key();
                    key.Row = "java-put2";
                    key.Column_family = "col";
                    cell.Key = key;
                    vtmp = "java-put-v2";
                    //// cell.Value = ByteBuffer.wrap(vtmp.getBytes());
					cell.Value = vtmp.getBytes();
                    client.shared_mutator_refresh(ns, "thrift_test", mutate_spec);
                    client.shared_mutator_set_cell(ns, "thrift_test", mutate_spec, cell);
                    System.Threading.Thread.Sleep(2000);
                }

                // scanner examples
                System.Console.WriteLine("Full scan");
                ScanSpec scanSpec = new ScanSpec(); // empty scan spec select all
                long scanner = client.scanner_open(ns, "thrift_test", scanSpec);



                try
                {
                    List<Cell> cells = client.scanner_get_cells(scanner);

                    //while (cells.size() > 0) 
                    while (cells.Count > 0)
                    {
                        foreach (Cell cell in cells)
                        {
                            byte[] tmp = cell.Value;

                            //string s = new string(tmp);
                            string s = StringExtensions.GetString(tmp);
                            show(s);
                        } // Next cell

                        cells = client.scanner_get_cells(scanner);
                    } // End While

                } // End Try
                catch { }
                finally
                {
                    client.scanner_close(scanner);
                }


                // restricted scanspec
                //scanSpec.addToColumns("col:/^.*$/");
                scanSpec.Columns.Add("col:/^.*$/");
                scanSpec.Row_regexp = "java.*";
                scanSpec.Value_regexp = "v2";
                scanner = client.scanner_open(ns, "thrift_test", scanSpec);
                System.Console.WriteLine("Restricted scan");



                try
                {
                    List<Cell> cells = client.scanner_get_cells(scanner);

                    //while (cells.size() > 0) 
                    while (cells.Count > 0)
                    {
                        foreach (Cell cell in cells)
                        {
                            byte[] tmp = cell.Value;
                            //string s = new string(tmp);
                            string s = StringExtensions.GetString(tmp);
                            show(s);
                        } // Next cell 

                        cells = client.scanner_get_cells(scanner);
                    } // End While 
                }
                catch (System.Exception)
                { }
                finally
                {
                    client.scanner_close(scanner);
                }



                // asynchronous api
                long future = 0;
                long mutator_async_1 = 0;
                long mutator_async_2 = 0;
                long color_scanner = 0;
                long location_scanner = 0;
                long energy_scanner = 0;
                int expected_cells = 6;
                int num_cells = 0;

                try
                {
                    System.Console.WriteLine("Asynchronous mutator");
                    future = client.future_open(0);
                    mutator_async_1 = client.async_mutator_open(ns, "thrift_test", future, 0);
                    mutator_async_2 = client.async_mutator_open(ns, "thrift_test", future, 0);
                    Result result;

                    Cell cell = new Cell();
                    Key key;

                    key = new Key();
                    key.Row = "java-put1";
                    key.Column_family = "col";
                    cell.Key = key;
                    string vtmp = "java-async-put-v1";
                    //cell.Value = ByteBuffer.wrap(vtmp.getBytes() );
					cell.Value = vtmp.getBytes();
                    client.async_mutator_set_cell(mutator_async_1, cell);

                    key = new Key();
                    key.Row = "java-put2";
                    key.Column_family = "col";
                    cell.Key = key;
                    vtmp = "java-async-put-v2";
                    //cell.Value = ByteBuffer.wrap(vtmp.getBytes() );
					cell.Value = vtmp.getBytes();
                    client.async_mutator_set_cell(mutator_async_2, cell);

                    client.async_mutator_flush(mutator_async_1);
                    client.async_mutator_flush(mutator_async_2);

                    int num_flushes = 0;
                    while (true)
                    {
                        result = client.future_get_result(future, 0);

                        if (result.Is_empty || result.Is_error || result.Is_scan)
                            break;

                        num_flushes++;
                    } // Whend

                    if (num_flushes > 2)
                    {
                        System.Console.WriteLine("Expected 2 flushes, received " + num_flushes);
                        System.Environment.Exit(1);
                    }
                    
                    if (client.future_is_cancelled(future) || client.future_is_full(future) ||
                        !client.future_is_empty(future) || client.future_has_outstanding(future))
                    {
                        System.Console.WriteLine("Future object in unexpected state");
                        System.Environment.Exit(1);
                    }
                }
                finally
                {
                    client.async_mutator_close(mutator_async_1);
                    client.async_mutator_close(mutator_async_2);
                }



                try
                {
                    System.Console.WriteLine("Asynchronous scan");
                    ScanSpec ss = new ScanSpec();
                    color_scanner = client.async_scanner_open(ns, "FruitColor", future, ss);
                    location_scanner = client.async_scanner_open(ns, "FruitLocation", future, ss);
                    energy_scanner = client.async_scanner_open(ns, "FruitEnergy", future, ss);
                    Result result;
                    while (true)
                    {
                        result = client.future_get_result(future, 0);
                        if (result.Is_empty || result.Is_error || !result.Is_scan)
                            break;

                        foreach (Cell cell in result.Cells)
                        {
                            byte[] tmp = cell.Value;
                            // string s = new string(tmp);
                            string s = StringExtensions.GetString(tmp);
                            show(s);
                            num_cells++;
                        } // Next cell 

                        if (num_cells >= 6)
                        {
                            client.future_cancel(future);
                            break;
                        }

                    } // Whend 

                    if (!client.future_is_cancelled(future))
                    {
                        System.Console.WriteLine("Expected future object to be cancelled");
                        System.Environment.Exit(1);
                    }
                } // End Try
                finally
                {
                    client.async_scanner_close(color_scanner);
                    client.async_scanner_close(location_scanner);
                    client.async_scanner_close(energy_scanner);
                    client.future_close(future);
                }


                if (num_cells != 6)
                {
                    System.Console.WriteLine("Expected " + expected_cells + " cells got " + num_cells.ToString());
                    System.Environment.Exit(1);
                }


                // issue 497
                {
                    Cell cell;
                    Key key;
                    string str;

                    client.hql_query(ns, "drop table if exists java_thrift_test");
                    client.hql_query(ns, "create table java_thrift_test ( c1, c2, c3 )");

                    mutator = client.mutator_open(ns, "java_thrift_test", 0, 0);

                    cell = new Cell();
                    key = new Key();
                    key.Row = "000";
                    key.Column_family = "c1";
                    key.Column_qualifier = "test";
                    cell.Key = key;
                    str = "foo";
                    // cell.Value = ByteBuffer.wrap(str.getBytes() );
					cell.Value = str.getBytes();
                    client.mutator_set_cell(mutator, cell);

                    cell = new Cell();
                    key = new Key();
                    key.Row = "000";
                    key.Column_family = "c1";
                    cell.Key = key;
                    str = "bar";
					//// cell.Value = ByteBuffer.wrap(str.getBytes() );
					cell.Value = str.getBytes();
                    client.mutator_set_cell(mutator, cell);

                    client.mutator_close(mutator);

                    HqlResult result = client.hql_query(ns, "select * from java_thrift_test");
                    List<Cell> cells = result.Cells;
                    int qualifier_count = 0;


                    foreach (Cell c in cells)
                    {
                        if (c.Key.__isset.column_qualifier && c.Key.Column_qualifier.Length == 0)
                            qualifier_count++;
                    } // Next c


                    if (qualifier_count != 1)
                    {
                        System.Console.WriteLine("ERROR: Expected qualifier_count of 1, got " + qualifier_count);
                        client.namespace_close(ns);
                        System.Environment.Exit(1);
                    } // End if (qualifier_count != 1)

                } // End Scope

                client.namespace_close(ns);
            } // End Try
            catch (System.Exception e)
            {
				System.Console.WriteLine (e.Message);
				System.Console.Error.WriteLine (e.StackTrace);
                
                try
                {
                    if (client != null && ns != -1)
                        client.namespace_close(ns);
				} 
				catch (System.Exception ex)
                {
					System.Console.WriteLine (ex.Message);
                    System.Console.Error.WriteLine("Problem closing namespace \"test\" - " + e.Message);
                }
                System.Environment.Exit(1);
            } // End Catch

        } // End Sub Main


        private static void show(string line)
        {
            System.Console.WriteLine(line);
        } // End Sub Show


    } // End Class


} // End Namespace
