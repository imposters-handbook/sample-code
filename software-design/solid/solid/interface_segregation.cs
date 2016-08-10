using System;
namespace InterfaceSegregation
{
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
    public IRegisterable Register (IRegisterable user)
    {
      //validations etc
      user.Status = "Registered";
      //save to the DB or something else
      return user;
    }
  }
}

