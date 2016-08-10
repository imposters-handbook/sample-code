using System;
using System.Collections.Generic;

namespace Bridge
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
    T Get<T>();
    T Save<T>();
    IList<T> Fetch<T>();
  }

  //implementation of the document query interface for
  //relational systems.
  public class RelationalDocumentQueryable : IDocumentQueryable
  {
    GroovyQuery _adapter;
    public RelationalDocumentQueryable (GroovyQuery adapter)
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

  }
  public class GroovySQLServerAdapter : GroovyQuery
  {
    public GroovySQLServerAdapter ()
    {
      this.Documents = new RelationalDocumentQueryable (this);
    }

    public override IList<T> FetchDocuments<T> ()
    {
      throw new NotImplementedException ();
    }

    public override T GetDocument<T> ()
    {
      throw new NotImplementedException ();
    }

    public override T SaveDocument<T> ()
    {
      throw new NotImplementedException ();
    }

  }
}

