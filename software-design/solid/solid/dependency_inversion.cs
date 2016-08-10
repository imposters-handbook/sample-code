using System;
namespace DI
{
  public interface IMembershipStore
  {
    void Save (object item);
  }

  public class PostgreSQLAdapter : IMembershipStore
  {
    public void Save (object item)
    {
      //database call...
    }
  }
  public interface IRegisterable
  {
    string Name { get; set; }
    string Email { get; set; }
    string Status { get; set; }
  }
  public class User : IRegisterable
  {
    public string Name { get; set; }
    public string Email { get; set; }
    public string Status { get; set; }
    public User ()
    {
      this.Name = "Guest";
      this.Status = "Anonymous";
    }
  }
  public class Membership
  {
    IMembershipStore _store;
    public Membership (IMembershipStore store)
    {
      _store = store;
    }
    public IRegisterable Register (IRegisterable user)
    {
      //validations etc
      user.Status = "Registered";
      _store.Save (user);
      return user;
    }
  }
}

