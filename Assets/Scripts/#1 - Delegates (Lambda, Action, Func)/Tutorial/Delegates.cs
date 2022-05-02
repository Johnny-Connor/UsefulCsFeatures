/* 
* Delegates are used to store a function/method in a variable. Having functions inside
* variables helps a lot in creating modular and cleaner codes.
*/

// 'Action' and 'Func' are two useful built-in delegates available in 'System'.
using System;
using UnityEngine;

public class Delegates : MonoBehaviour
{

    #region Variables used in regions #1 and #2
    // Creating the 'TestDelegate' type, which will store methods (returns void).
    private delegate void TestDelegate();

    /*
    * Creating the 'TestBoolDelegate' type, which will store functions that
    * receives a 'int' value as the argument and return a 'bool' value.
    */
    private delegate bool TestBoolDelegate(int i);

    // Creating a variable of type 'TestDelegate'.
    private TestDelegate testDelegate;

    // Creating a variable of type 'TestBoolDelegate'.
    private TestBoolDelegate testBoolDelegate;
    #endregion Variables used in regions #1 and #2
    
    #region Variables used in region #3
    /*
     * 'Func' and 'Action' makes it possible to create a delegate without having
     * to directly define it.
     * 'Func' is used to define a delegate for a function (has a return).
     * 'Action' is used to define a delegate for a method (no return).
    */

    // Stores methods that don't receive any arguments.
    private Action testAction;

    // Stores methods that receives 'int' and 'float' values as arguments.
    private Action<int, float> testIntFloatAction;

    // Stores functions with no arguments that return 'bool'.
    private Func<bool> testFunc;

    /*
    * The last 'Func' parameter is what the stored functions should return.
    * In this case, the stored functions should receive two 'int's and return a bool.
    */
    private Func<int, float, bool> testFunc2;
    #endregion Variables used in region #3

    private void Awake()
    {
        #region #1 - Basics
        Debug.Log("<color=green>Region #1</color>");

        // Storing 'MyTestDelegateMethod' method in the 'testDelegate' variable.
        testDelegate = MyTestDelegateMethod;

        // Instantiating the stored method by just mentioning the variable.
        testDelegate();

        // Storing 'MySecondTestDelegateMethod' method in the 'testDelegate' variable.
        testDelegate = MySecondTestDelegateMethod;

        // Instantiating the stored method by just mentioning the variable.
        testDelegate();

        // Storing 'MyTestBoolDelegateFunction' function in the 'testBoolDelegate' variable.
        testBoolDelegate = MyTestBoolDelegateFunction;

        // Instantiating the stored function by just mentioning the variable.
        Debug.Log(testBoolDelegate(2));

        /*
        * Delegates can also be used to instantiate multiple functions/methods at 
        * once (multicast). Normally, this is how delegates are used in events.
        */
        testDelegate = MyTestDelegateMethod;

        /*
        * Note 1: subtracting is also possible.
        * Note 2: this is not an array, meaning that it's not possible to choose which
        * of the stored functions in this variable will be instantiated.
        */
        testDelegate += MySecondTestDelegateMethod;
        testDelegate();
        #endregion #1 - Basics

        #region #2 - Anonymous function/methods and Lambda Expressions
        Debug.Log("<color=green>Region #2</color>");

        /*
        * It's possible to create a function/method within a code block by creating
        * an anonymous function/method.
        * In most cases, doing this is a better option than creating a separated
        * function/method just to attribute it to a delegate variable.
        */
        testDelegate = delegate() { Debug.Log("Anonymous method."); };
        testDelegate();

        /* 
        * Further compaction is made possible by Lambda expressions, where:
        * '()' is a reference to the anonymous function/method arguments.
        * '=>' is a Lambda operator (used to separate the arguments from the
        * function content).
        * '{}' is the function/method instructions.
        * Lambda expressions are the easiest and most compact way of creating an
        * anonymous function/method.
        */

        // This is the syntax for Lambda methods.
        testDelegate = () => { Debug.Log("Anonymous method created with a Lambda expression."); };
        testDelegate();

        // This is the syntax for Lambda functions.
        testBoolDelegate = (int i) => { return i < 5; };

        /* 
        * Tip: Lambda functions/methods which have only one instruction can be
        * further compacted:
        */
        testBoolDelegate = (int i) => i < 5;
        Debug.Log(testBoolDelegate(2));
        #endregion #2 - Anonymous function/methods and Lambda Expressions
    
        #region #3 - Func/Action
        Debug.Log("<color=green>Region #3</color>");

        testAction = () => Debug.Log("testAction");
        testAction();
        
        testIntFloatAction = (int i, float f) =>  Debug.Log("i:" + i + "    f:" + f);
        testIntFloatAction(5, 7.5f);
        
        testFunc = () => false;
        Debug.Log(testFunc());
        
        testFunc2 = (int i, float i2) => i > i2;
        Debug.Log(testFunc2(10, 5));
        #endregion #3 - Func/Action
    }

    #region Named Functions
    private void MyTestDelegateMethod(){
        Debug.Log("MyTestDelegateFunction.");
    }

    private void MySecondTestDelegateMethod(){
        Debug.Log("MySecondTestDelegateFunction.");
    }

    private bool MyTestBoolDelegateFunction(int i){
        return i < 5;
    }
    #endregion Named Functions
    
}