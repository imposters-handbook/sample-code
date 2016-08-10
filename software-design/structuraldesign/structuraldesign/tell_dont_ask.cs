using System;
using System.Data;

namespace TellDontAsk
{
  public class GroovyQuery // Asking
  {
    public bool IsCommandValid (IDbCommand cmd)
    {
      //logic
      return true;
    }
    public bool IsConnectionAvailable ()
    {
      //check connection pool to see if one is ready
      return true;
    }
    public IDataReader Execute (IDbCommand cmd)
    {
      //execution
      return null;
    }
  }

  public class GroovyQuery2 //Telling
  {
    bool CommandIsValid (IDbCommand cmd)
    {
      //logic
      return true;
    }
    bool ConnectionIsAvailable ()
    {
      //check connection pool to see if one is ready
      return true;
    }
    public IDataReader Execute (IDbCommand cmd)
    {
      var commandIsValid = CommandIsValid (cmd);

      if (ConnectionIsAvailable () && commandIsValid) {
        //execution
        return null;
      } else {
        throw new InvalidOperationException ("Can't run this query");
      }

    }
  }
}

