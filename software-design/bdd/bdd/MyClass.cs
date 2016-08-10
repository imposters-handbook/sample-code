using System;
using XUnit;

namespace BillingSystem.Specs {
  
  [Trait("Monthly Payment Is Due", "Payment Is Received")]
  public class PaymentReceived{
    //... the constructor prepares the test data
    [Fact]
    public void An_Invoice_Is_Created(){
        //...
    }
    [Fact]
    public void Subscription_Status_Is_Updated(){
        //...
    }
    [Fact]
    public void Next_Billing_Is_Set_1_Month_From_Now(){
        //...
    }
    [Fact]
    public void A_Notification_Is_Sent_To_Subscriber(){
        //...
    }
    //...
  }
  [Trait("Monthly Billing", "Payment Fails")]
  public class SubscriptionPaymentIsDue{
    //... the constructor prepares the test data
    [Fact]
    public void An_Invoice_Is_Not_Created(){
        //...
    }
    [Fact]
    public void Next_Billing_Is_1_Day_From_Now(){
        //...
    }
    [Fact]
    public void A_Notification_Is_Sent_To_Subscriber(){
        //...
    }
    //...
  }
}