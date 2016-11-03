using Moq;
using Xunit;
namespace BillingSystem.Tests3
{
  public interface ICustomerRepository { }
  public interface ICreditCardCharger { }
  public class BillingDoohickeyTests3
  {
    [Fact]
    public void Monkey ()
    {
      var repo = new Mock<ICustomerRepository> ();
      var charger = new Mock<ICreditCardCharger> ();
      BillingDoohickey thing = new BillingDoohickey (repo.Object, charger.Object);
      thing.ProcessMonth (2016, 8);
    }
    //Monthly billing
    //Grace period for missed payments
    //Not all customers are necessarily subscribers
    //Idle customers should be automatically unsubscribed
  }
  public class BillingDoohickey
  {
    public BillingDoohickey (ICustomerRepository repo, ICreditCardCharger charger){}
    public int ProcessMonth (int year, int month) {return 0;}
  }
  public class Customer{}
}
