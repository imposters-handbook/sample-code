public class BinaryNode
{
  public int Value { get; }
  //child nodes
  public BinaryNode Left { get; set; }
  public BinaryNode Right { get; set; }

  public BinaryNode(int value)
  {
    Value = value;
  }
  public bool IsLeaf(){
    return this.Left == null && this.Right == null;
  }
  public void Traverse(BinaryNode node){
    if(node.Left != null){
      Traverse(node.Left);
    }
    if(node.Right != null){
      Traverse(node.Right);
    }
    //Leaf node!
    if(this.IsLeaf()){
      //we're done!
    }
  }
}

var rootNode = new BinaryNode(0);
rootNode.Left = new BinaryNode(1);
rootNode.Right = new BinaryNode(2);
rootNode.Left.Left = new BinaryNode(3);
rootNode.Left.Right = new BinaryNode(4);
rootNode.Right.Left = new BinaryNode(5);
rootNode.Right.Right = new BinaryNode(6);


public class DFS{
  public void Traverse(BinaryNode root){
    var stack = new Stack<BinaryNode>();
    BinaryNode thisNode = null;
    //push the root onto the stack
    stack.Push(root);
    while(stack.Count > 0){
      thisNode = stack.Pop();
      Console.WriteLine(thisNode.Value);
      //push right then left
      if(thisNode.Right != null){
        stack.Push(thisNode.Right);
      }
      if(thisNode.Left != null){
        stack.Push(thisNode.Left);
      }
    }
  }
}

public class DFS{
  public void Traverse(BinaryNode root){
    //...
  }
  public void Run(){
    var rootNode = new BinaryNode(0);
    rootNode.Left = new BinaryNode(1);
    rootNode.Right = new BinaryNode(2);
    rootNode.Left.Left = new BinaryNode(3);
    rootNode.Left.Right = new BinaryNode(4);
    rootNode.Right.Left = new BinaryNode(5);
    rootNode.Right.Right = new BinaryNode(6);
    this.Traverse(rootNode);
  }
}

public class BFS{
  public void Traverse(BinaryNode root){
    var queue = new Queue<BinaryNode>();
    BinaryNode thisNode = null;
    //push the root onto the queue
    queue.Enqueue(root);
    while(queue.Count > 0){
      //remove the next item from the queue
      thisNode = queue.Dequeue();
      //do whatever calc
      Console.WriteLine(thisNode.Value);
      //add the children into the queue
      if(thisNode.Left != null){
        queue.Enqueue(thisNode.Left);
      }
      if(thisNode.Right != null){
        queue.Enqueue(thisNode.Right);
      }
    }
  }
}