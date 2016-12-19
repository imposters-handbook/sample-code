using Moq;
using Xunit;
namespace BillingSystem.Tests5 {
  public interface ICustomerRepository { }
  public interface ICreditCardCharger { }
  public class MonthlyChargeTests {

    [Fact]
    public void Customers_With_Subscriptions_Due_Are_Charged () {
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
  public class BillingDoohickey {
    public BillingDoohickey (ICustomerRepository repo,
                             ICreditCardCharger charger){}
    public int ProcessMonth (int year, int month){
      return 1; //do just enough
    }
  }
  public class Customer{}
}
