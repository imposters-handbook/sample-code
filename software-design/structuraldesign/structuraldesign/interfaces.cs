using System;
using System.Collections.Generic;

namespace Interfaces
{
  public class User
  {
    public String Status { get; set; }
  }

  public interface IDataStore
  {
    void Save<T> (T item);
    T Get<T> (int id);
    IList<T> Fetch<T> ();
  }

  public class Membership
  {
    IDataStore _db;
    public Membership (IDataStore db)
    {
      _db = db;
    }
    public User GetUser (int id)
    {
      //get the user
      return _db.Get<User> (id);
    }
    public void SuspendUser (int id)
    {
      var user = this.GetUser (id);
      user.Status = "suspended";
      _db.Save (user);
    }
  }
}
