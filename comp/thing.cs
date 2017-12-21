public class MyClass {
  public MyClass(){
    var x = 100;
  }
}

public class MyClass {
  int x;
  public MyClass(){
      x = 100;
  }
}

if(1 === 1){
  var x = 12;
}
console.log(x); //12

public class ScopeTest
{
  [Fact]
  public void TheScopeOfXIsLexical()
  {
    if(1 == 1){
        var x = 12;
    }
    Console.WriteLine(x);
  }
}

error CS0103: The name 'x' does not exist in the current context


public class MultiplyingByZero
{
  [Fact]
  public void UsingNaN()
  {
    double x = Double.NaN;
    Console.WriteLine(x * 0); // NaN
  }
}


public class Customer{
  public int ID {get;set;}
  //...

  public Order CurrentSalesOrder{get;set;}
  public Customer(int id){
      //fetch the current order from the db
      this.CurrentSalesOrder = db.getCurrentOrder(id);
  }
}

public class Order{
  public int ID {get;set;}
  //...

  public Customer Buyer{get;set;}
  public Order(GUID key){
      this.Customer = db.getCustomerForOrder(key);
  }
}