/*
* Generics are a feature of C# that makes it possible to create generic variables, which are
* capable of receiving any type, including custom ones. With them, it's possible to write
* codes that can be used in many scenarios.
*/

using System;
using UnityEngine;

public class Generics : MonoBehaviour
{

    /*
    * The generic type works in every situation involving variables! This tutorial will show
    * some examples.
    * Tip: it's a good practice to name the generic type as 'T' or something that starts
    * with it (e.g.: TMyCustomType).
    */

    private void Start()
    {
        int[] MyIntArray = GenericArray(5, 6);
        Debug.Log(MyIntArray.Length + " " + MyIntArray[0] + " " + MyIntArray[1]);

        string[] MyStringArray = GenericArray("first", "second");
        Debug.Log(MyStringArray.Length + " " + MyStringArray[0] + " " + MyStringArray[1]);

        MyClass<float> myClass = new MyClass<float>();

        MySecondClass<EnemyArcher> enemyArcher = new MySecondClass<EnemyArcher>(new EnemyArcher());
        MySecondClass<EnemyKnight> enemyKnight = new MySecondClass<EnemyKnight>(new EnemyKnight());

    }

    // This generic function can set the first two values of any array type.
    private T[] GenericArray<T>(T firstElement, T secondElement){
        return new T[] { firstElement, secondElement };
    }

    /*
    * To be able to receive different types at once (e.g.: int and string) as arguments, the
    * generic function needs to have multiple generics ("'T1', 'T2', 'T3'...).
    */
    private void MultiGenericTest<T1, T2>(T1 t1, T2 t2) {
        Debug.Log(t1.GetType());
        Debug.Log(t2.GetType());
    }

    // A class which stores a generic value.
    public class MyClass<T> {

        public T value;
        
    }

    /*
    * This class has 3 constraints: it only accepts types that are a class, inherits the
    * 'IEnemy' interface and have a constructor.
    * The list of every available constraint in C# can be found at:
    * https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/generics/constraints-on-type-parameters
    */
    public class MySecondClass<T> where T : class, IEnemy, new() {

        public T value;

        public MySecondClass(T value){
            value.Damage(); // A constructor can call functions/methods by itself.
        }

    }

    public interface IEnemy {

        void Damage();

    }

    public class EnemyArcher : IEnemy {

        public void Damage(){
            Debug.Log("EnemyArcher.Damage()");
        }

    }

    public class EnemyKnight : IEnemy {

        public void Damage(){
            Debug.Log("EnemyKnight.Damage()");
        }

    }

}
