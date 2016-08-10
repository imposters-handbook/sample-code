using System;
using System.Collections.Generic;

namespace Builder
{
  public class NaiveStringBuilder
  {
    IList<string> _strings;
    public NaiveStringBuilder ()
    {
      _strings = new List<string> ();
    }
    public void Append (string val)
    {
      _strings.Add (val);
    }
    public override string ToString ()
    {
      var result = "";
      foreach (var s in _strings) {
        result = result + s + " "; // a new string is built each time
      }
      return result;
    }
  }



  public class Message
  {
    System.Text.StringBuilder _stringBuilder;
    public Message (string initialValue)
    {
      _stringBuilder = new System.Text.StringBuilder ();
      _stringBuilder.Append (initialValue);
    }
    public Message Add (string value)
    {
      _stringBuilder.Append (" ");
      _stringBuilder.Append (value);
      return this;
    }
    public override string ToString ()
    {
      return _stringBuilder.ToString ();
    }
  }


}

