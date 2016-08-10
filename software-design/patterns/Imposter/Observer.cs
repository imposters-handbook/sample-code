using System;
using System.Collections.Generic;
using System.Data;

namespace Observer
{
  public interface IListener
  {
    void Notify<T> (T result);
    void Notify ();
  }
  public abstract class GroovyQuery
  {
    //API methods etc
    //...
    public IList<IListener> Listeners { get; set; }
    public GroovyQuery ()
    {
      //constructor stuff
      //...
      this.Listeners = new List<IListener> ();
    }
    public virtual IDataReader Execute (IDbCommand cmd)
    {
      //the execution stuff
      //notify all listeners
      foreach (var listener in this.Listeners) {
        listener.Notify ();//optionally send along some data
      }
      return null;
    }
  }
}

