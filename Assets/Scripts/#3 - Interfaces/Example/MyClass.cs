using UnityEngine;

/*
* Inheriting 'MonoBehaviour' and 'IMyInterface'. 
* Note: it's possible to inherit multiple interfaces.
*/
public class MyClass : MonoBehaviour, IMyInterface
{

    private void Start() {
        IMyInterfaceFunction();
    }

    // The elements from 'IMyInterface' must be added.
    public void IMyInterfaceFunction(){
        Debug.Log("MyClass.IMyInterfaceFunction()");
    }

}
