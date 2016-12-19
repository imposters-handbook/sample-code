//...
  [Trait ("Monthly Billing", "Payment Fails")]
  public class SubscriptionPaymentIsDue
  {
    [Fact]
    public void An_Invoice_Is_Not_Created(){}

    [Fact]
    public void Next_Billing_Is_1_Day_From_Now(){}

    [Fact]
    public void A_Notification_Is_Sent_To_Subscriber(){}

  }

//...
