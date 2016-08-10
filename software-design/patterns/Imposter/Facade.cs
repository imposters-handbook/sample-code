using System;
using System.Collections.Generic;

namespace Facade
{

  //abstract base class
  public abstract class GroovyQuery
  {
    public GroovyQuery (string connectionString) { }
  }

  //implementation for PostgreSQL
  public class PostgreSQLQuery : GroovyQuery {
    public PostgreSQLQuery (string connectionString) : base (connectionString){}
  }

  //implementation for SQL Server
  public class SQlServerQuery : GroovyQuery
  {
    public SQlServerQuery (string connectionString) : base (connectionString) { }
  }


  //a simple class that hides the selection details
  public class QueryRunner 
  {

    string _connectionString;

    //Find, Fetch, and Save use the _adapter passed in 
    public QueryRunner (string connectionString)
    {
      _connectionString = connectionString;
    }

    public void Execute ()
    {

      GroovyQuery runner;
      if (_connectionString.StartsWith ("postgresql://", StringComparison.InvariantCultureIgnoreCase)) {
        runner = new PostgreSQLQuery (_connectionString);
      } else if (_connectionString.StartsWith ("sqlserver://", StringComparison.InvariantCultureIgnoreCase)) {
        runner = new SQlServerQuery (_connectionString);
      } else {
        throw new InvalidOperationException ("We don't support that");
      }

      //execute with the runner
    }

  }
}

