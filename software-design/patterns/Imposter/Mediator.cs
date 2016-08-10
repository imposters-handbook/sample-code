using System;
using System.Collections.Generic;

namespace Mediator
{
  public interface IDocumentQueryable
  {
    T Get<T> ();
    T Save<T> ();
    IList<T> Fetch<T> ();
  }
  public abstract class GroovyQuery
  {
    //groovy interface
    public abstract T GetDocument<T> ();
    public abstract T SaveDocument<T> ();
    public abstract IList<T> FetchDocuments<T> ();

    public IDocumentQueryable Documents;
    //etc
  }
public class DocumentStore
  {
    GroovyQuery _adapter;
    public DocumentStore (GroovyQuery adapter)
    {
      _adapter = adapter;
    }
    public T Save<T> (T item)
    {
      //parse and save the object
      return item;
    }
    public T Get<T> ()
    {
      //pull the record, dehydrate
      return default(T);
    }
    public IList<T> Fetch<T> ()
    {
      //pull the list, dehydrate
      return new List<T>();
    }
    string Dehydrate<T> (T item)
    {
      //turn the object into JSON
      return "";
    }
    T Hydrate<T> (string json)
    {
      //resolve
      return default(T);
    }
  }
}

