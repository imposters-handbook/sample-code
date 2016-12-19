using Moq;
using Xunit;

namespace BillingSystem.Tests7
{
  public interface ICustomerRepository {
    Customer [] Customers();
  }
  public interface ICreditCardCharger { }
  public class MonthlyChargeTests {

    ICustomerRepository repo;
    ICreditCardCharger charger;
    BillingDoohickey thing;
    Mock<ICustomerRepository> repoMock;

    public MonthlyChargeTests () {
      repoMock = new Mock<ICustomerRepository> ();
      repo = repoMock.Object;
      charger = new Mock<ICreditCardCharger> ().Object;
      thing = new BillingDoohickey (repo, charger);
    }

    [Fact]
    public void Customers_With_Subscriptions_Due_Are_Charged(){
      repoMock.Setup (r => r.Customers())
          .Returns (new Customer [] { new Customer () });

      var processed = thing.ProcessMonth (2016, 8);
      Assert.True (processed > 0);
    }

    [Fact]
    public void Customers_With_No_Subscriptions_Due_Are_Not_Charged (){
      repoMock.Setup (r => r.Customers())
              .Returns (new Customer [] { });

      var processed = thing.ProcessMonth (2016, 8);
      Assert.True (processed == 0);
    }

  }

  public class BillingDoohickey{
    ICustomerRepository _repo;
    public BillingDoohickey (ICustomerRepository repo,
                             ICreditCardCharger charger) {
      _repo = repo;
    }
    public int ProcessMonth (int year, int month){
      return _repo.Customers().Length;
    }
  }
  public class Customer {}
}
