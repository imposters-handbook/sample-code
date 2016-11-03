using System.Collections.Generic;
using System.Linq;
using Moq;
using Xunit;

namespace BillingSystem.Tests8
{
  public interface ICustomerRepository {
    Customer [] Customers ();
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
    public void Customers_With_Subscriptions_Due_Are_Charged () {
      repoMock.Setup (r => r.Customers ())
          .Returns (new Customer [] { new Customer () });

      var processed = thing.ProcessMonth (2016, 8);
      Assert.Equal (0, processed);
    }

    [Fact]
    public void Customers_With_No_Subscriptions_Due_Are_Not_Charged () {
      repoMock.Setup (r => r.Customers ())
              .Returns (new Customer [] { });

      var processed = thing.ProcessMonth (2016, 8);
      Assert.Equal (processed, 0);
    }

    [Fact]
    public void A_Customer_With_Two_Subscriptions_Due_Is_Charged_Twice () {
      var customer = new Customer ();
      customer.Subscriptions.Add (new Subscription ());
      customer.Subscriptions.Add (new Subscription ());

      repoMock.Setup (r => r.Customers())
          .Returns (new Customer [] { customer });

      var processed = thing.ProcessMonth (2016, 8);
      Assert.Equal (2, processed);
    }


  }
  public class BillingDoohickey
  {
    ICustomerRepository _repo;
    public BillingDoohickey (ICustomerRepository repo, ICreditCardCharger charger){
      _repo = repo;
    }
    public int ProcessMonth (int year, int month){
      var customer = _repo.Customers ().FirstOrDefault ();
      if (customer == null) {
        return 0;
      } else {
        return customer.Subscriptions.Count ();
      }

    }
  }
  public class Customer {
    public IList<Subscription> Subscriptions { get; set;}

    public Customer () {
      this.Subscriptions = new List<Subscription> ();
    }
  }
  public class Subscription { }
}
