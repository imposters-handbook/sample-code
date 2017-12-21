public class LinkedListNode{
  public int Value { get; set; } 
  public LinkedListNode Next { get; set; }
  public LinkedListNode(int Value)
  {
      this.Value = value;
  }
}
var a = new LinkedListNode(1);
var b = new LinkedListNode(2);
var c = new LinkedListNode(3);

a.Next = b;
b.Next = c;



var thisNode = a;
while(thisNode != null){
  //do something
  //...
  //traverse
  thisNode = thisNode.Next;
}

