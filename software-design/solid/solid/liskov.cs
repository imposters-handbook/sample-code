using System;
namespace Liskov
{
  public class Rectangle
  {
    int _height;
    int _width;

    public virtual void SetHeight (int height)
    {
      _height = height;
    }
    public virtual void SetWidth (int width)
    {
      _width = width;
    }
  }
  public class Square : Rectangle
  {

    public override void SetHeight (int height)
    {
      this.SetHeight (height);
      this.SetWidth (height);
    }
    public override void SetWidth (int width)
    {
      this.SetHeight (width);
      this.SetWidth (width);
    }
  }
}

