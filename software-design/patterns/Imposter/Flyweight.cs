using System;
using System.Collections.Generic;

namespace Flyweight
{
  //our Flyweight class
  public class Table
  {
    public string Name { get; set; }
    public string PrimaryKeyField { get; set; }
    //column and data type information...
  }

  public abstract class GroovyQuery
  {
    //the API as we've come to know it
    List<Table> _tables;
    public void Initialize ()
    {
      _tables = new List<Table> ();
      //query the database for meta information
      //load up the _tables list
    }
  }
}

