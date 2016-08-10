using System;
using System.Collections;
using System.Collections.Generic;

namespace Factory
{
  public class Administrator : Customer
  {
    //specific fields/methods for admins
  }

  public class Order
  {

  }

  public class Customer
  {
    public string Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Status { get; set; }
    public List<Order> Orders { get; set; }

    public static Customer FromDefaults ()
    {
      var customer = new Customer { Status = "unregistered", Name = "Guest" };
      customer.Orders = new List<Order> ();
      return customer;
    }

    public static Customer FromExisting (IDictionary values)
    {

      var customer = new Customer ();
      //populate the values on the class, validating etc.

      return customer;

    }
  }

  public class CustomerFactory
  {
    public Customer FromDefaults ()
    {
      var customer = new Customer { Status = "unregistered", Name = "Guest" };
      customer.Orders = new List<Order> ();
      return customer;
    }

    public Customer FromExisting (IDictionary values)
    {
      if (values.Contains ("Email")) {
        if (values ["Email"].ToString () == "admin@example.com") {
          var admin = new Administrator ();
          //populate values
          return admin;
        } else {
          var customer = new Customer ();
          //populate the values on the class, validating etc.

          return customer;
        }
      } else {
        return null;
      }
    }
  }
}
