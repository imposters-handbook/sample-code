using System;
using System.Collections.Generic;

namespace Composite
{
  public class Connection
  {
    public bool CheckedOut { get; set; }
    public Connection (string connectionString)
    {
      //connect
    }
    public void Close ()
    {
      //close the connection
    }
  }

  public class ConnectionPool
  {
    public IList<Connection> Pool;
    public ConnectionPool (string connectionString)
    {
      this.Pool = new List<Connection> ();
      for (var i = 0; i < 10; i++) {
        this.Pool.Add (new Connection (connectionString));
      }
    }
    public void Checkout ()
    {
      //grab a list of connections which aren't checked out
      //return the first
    }
    public void Checkin ()
    {
      //tick the boolean
    }
    public void Drain ()
    {
      foreach (var connection in this.Pool) {
        connection.Close ();
      }
      this.Pool = new List<Connection> ();
    }
  }
}

