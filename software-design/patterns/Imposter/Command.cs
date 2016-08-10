using System;
using System.Collections.Generic;
using System.Data;

namespace Command
{
  public class QueryParameter
  {
    public QueryParameter (string name, string value)
    {
      this.Name = name;
      this.Value = value;
    }
    public string Name { get; private set; }
    public string Value { get; private set; }
  }
  public interface IQueryCommand
  {
    string SQL { get; set; }
    IList<QueryParameter> Parameters { get; set; }
    IDbCommand BuildCommand ();
  }
  public class QueryCommand : IQueryCommand
  {
    public string SQL { get; set; }
    public IList<QueryParameter> Parameters { get; set; }
    public IDbCommand BuildCommand ()
    {
      //return a command that can be executed
      //...
      return null;
    }
  }
  public class GroovyQuery
  {
    //the API
    //...
    public IDataReader Execute (IQueryCommand cmd)
    {
      //build the command and execute it
      var dbCommand = cmd.BuildCommand ();
      //...
      return null;
    }
  }

  public class CreateUserCommand : QueryCommand
  {
    public CreateUserCommand (string name, string email, string password)
    {
      this.SQL = @"insert into users(name, email, hashed_password)
                 values(@1, @2, @3);";
        
      this.Parameters = new List<QueryParameter> ();
      this.Parameters.Add (new QueryParameter("@1", name));
      this.Parameters.Add (new QueryParameter("@2", email));
      this.Parameters.Add (new QueryParameter("@3", SomeHashingAlgorithm (password)));
    }
    private string SomeHashingAlgorithm (string val)
    {
      //some solid hashing here...
      return "";
    }
  }
}

