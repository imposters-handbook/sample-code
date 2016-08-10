using System;
using System.Collections.Generic;


namespace Chain
{


  public class User
  {
    public string Name { get; set; }
    public int Age { get; set; }
    public bool IsValid = false;
    public System.Text.StringBuilder ValidationMessages;

    public User ()
    {
      this.ValidationMessages = new System.Text.StringBuilder ();
      this.ValidationMessages.AppendLine ("Pending save");
    }
    public void Validate ()
    {
      var nameCheck = new NameValidator ();
      var ageCheck = new AgeValidator ();
      nameCheck.SetSuccessor (ageCheck);

      //kick it off
      nameCheck.Validate (this);
    }
  }

  public abstract class UserValidator
  {
    protected UserValidator Successor = null;
    public void SetSuccessor (UserValidator successor)
    {
      this.Successor = successor;
    }

    public abstract void Validate (User user);
    public void HandleNext (User user)
    {
      if (user.IsValid && this.Successor != null) {
        this.Successor.Validate (user);
      }
    }
  }

  public class NameValidator : UserValidator
  {
    public override void Validate (User user)
    {
      user.IsValid = !String.IsNullOrEmpty (user.Name);

      if (user.IsValid) {
        user.ValidationMessages.AppendLine ("Name validated");
      } else {
        user.ValidationMessages.AppendLine ("No name given");
      }
      HandleNext (user);
    }

  }

  public class AgeValidator : UserValidator
  {
    public override void Validate (User user)
    {
      user.IsValid = user.Age > 18;
      if (user.IsValid) {
        user.ValidationMessages.AppendLine ("Age validated");
      } else {
        user.ValidationMessages.AppendLine ("Age is invalid - must be over 18");
      }
      HandleNext (user);
    }
  }

}