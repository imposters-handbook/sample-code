using System;

namespace Imposter
{
  class MainClass
  {
    public static void Main (string [] args)
    {
      //factory
      var customer = Factory.Customer.FromDefaults ();

      //factory class
      var customerFactory = new Factory.CustomerFactory ();
      var customer2 = customerFactory.FromDefaults ();

      //builder
      var naiveBuilder = new Builder.NaiveStringBuilder ();
      naiveBuilder.Append ("This");
      naiveBuilder.Append ("could be");
      naiveBuilder.Append ("very long");
      naiveBuilder.Append ("and blow up");
      naiveBuilder.Append ("your program...");
      var badBuilderResult = naiveBuilder.ToString ();//OUCH

      var goodBuilder = new System.Text.StringBuilder ();
      goodBuilder.Append ("This ");
      goodBuilder.Append ("won't ");
      goodBuilder.Append ("blow up ");
      goodBuilder.Append ("my program ");
      var goodBuilderResult = goodBuilder.ToString (); //yay!

      var message = new Builder.Message ("Hello").Add ("I might be").Add ("a really long string").ToString ();

      //singleton
      var single = Singleton.SingleThing.Instance ();

      //composite
      var connectionPool = new Composite.ConnectionPool ("test");

      //Facade
      var query = new Facade.QueryRunner ("postgresql://test");


      //Chain of Command
      var user = new Chain.User { Name = "Larry", Age = 22 };
      user.Validate ();

      var user2 = new Chain.User { Name = "Larry", Age = 16 };
      user2.Validate ();

      Console.WriteLine (customer.Name);
      Console.WriteLine (customer2.Name);
      Console.WriteLine (badBuilderResult);
      Console.WriteLine (goodBuilderResult);
      Console.WriteLine (message.ToString());
      Console.WriteLine (connectionPool.Pool.Count);
      Console.WriteLine (user.ValidationMessages.ToString());
      Console.WriteLine (user2.ValidationMessages.ToString ());
      Console.Read ();
    }
  }
}
