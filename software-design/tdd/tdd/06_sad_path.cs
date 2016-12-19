using Moq;
using Xunit;

namespace BillingSystem.Tests6 {
  public interface ICustomerRepository { }
  public interface ICreditCardCharger { }
  public class MonthlyChargeTests {

    ICustomerRepository repo;
    ICreditCardCharger charger;
    BillingDoohickey thing;

    public MonthlyChargeTests (){
      repo = new Mock<ICustomerRepository>().Object;
      charger = new Mock<ICreditCardCharger>().Object;
      thing = new BillingDoohickey (repo, charger);
    }

    [Fact]
    public void Customers_With_Subscriptions_Due_Are_Charged () {
      var processed = thing.ProcessMonth (2016, 8);
      Assert.True (processed > 0);
    }

    [Fact]
    public void Customers_With_No_Subscriptions_Due_Are_Not_Charged () {
      var processed = thing.ProcessMonth (2016, 8);
      Assert.True (processed == 0);
    }

  }
  //...
  
  public class BillingDoohickey
  {
    public BillingDoohickey (ICustomerRepository repo,
                             ICreditCardCharger charger){

    }
    public int ProcessMonth (int year, int month) {
      return 1; //do just enough
    }
  }
  public class Customer{}
}
