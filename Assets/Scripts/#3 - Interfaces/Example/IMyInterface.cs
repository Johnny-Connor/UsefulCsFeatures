/*
* Creating an Interface.
* Tip: it's a good practice to start the name of interfaces with an 'I'.
*/
public interface IMyInterface
{

    /*
    * In an Interface, every element has to be public. That means that there is no need to
    * use accessors, for everything is set to be public automatically.
    * Also, since Interfaces don't have any implementation, it's elements shouldn't have any
    * code blocks ('{}').
    * Note: With 'Default Interface Methods' (from C# 8.0), the mechanisms above are more
    * malleable. However, since Unity doesn't support it, the old methodology will be used
    * instead.
    */
    void IMyInterfaceFunction();

}
