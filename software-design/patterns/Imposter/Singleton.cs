using System;
namespace Singleton
{
  public class SingleThing
  {
    //single instance holder
    private static SingleThing _instance;
    //disallow calling constructor directly
    protected SingleThing () { }
    //access to the instance
    public static SingleThing Instance ()
    {
      if (_instance == null) {
        _instance = new SingleThing ();
      }
      return _instance;
    }
  }
}
