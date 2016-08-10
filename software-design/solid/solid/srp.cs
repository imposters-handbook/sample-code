using System;
namespace SRP
{
  public class User
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
    public User Register (string name, string email)
    {
      //validations etc
      var newUser = new User { Name = name, Email = email, Status = "Registered" };
      //save to the DB or something else
      return newUser;
    }
  }
}

