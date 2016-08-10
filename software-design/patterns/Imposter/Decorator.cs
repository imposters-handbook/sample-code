using System;
using System.Collections.Generic;

namespace Decorator
{
  public abstract class GroovyQuery
  {
    //groovy interface
    public abstract T GetDocument<T> ();
    public abstract T SaveDocument<T> ();
    public abstract IList<T> FetchDocuments<T> ();

    public IDocumentQueryable Documents;
    //etc
  }

  public interface IDocumentQueryable
  {
    T Get<T> ();
    T Save<T> ();
    IList<T> Fetch<T> ();
  }

  //implementation of the document query interface for
  //relational systems.
  public class RelationalDocumentDecorator : IDocumentQueryable
  {
    GroovyQuery _adapter;

    //Find, Fetch, and Save use the _adapter passed in 
    public RelationalDocumentDecorator (GroovyQuery adapter)
    {
      this._adapter = adapter;
    }

    public IList<T> Fetch<T> ()
    {
      throw new NotImplementedException ();
    }

    public T Get<T> ()
    {
      throw new NotImplementedException ();
    }


    public T Save<T> ()
    {
      throw new NotImplementedException ();
    }
    //implement Get, Save, Fetch for Documents below
  }
}

