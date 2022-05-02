// 'EventHandler' is one of the built-in delegates available in 'System'.
using System;
using UnityEngine;

public class Publisher : MonoBehaviour
{

    /*
    * The 'event' keyword defines that this field is going to be an event.
    * 'EventHandler' is a delegate with two fields:
    * - An 'object' for the sender, which is the source of the event.
    * - An 'EventArgs', used to pass more information through the event, if necessary.
    * Tip: it's a good practice to name events with 'On' as a prefix.
    */
    // 'OnSpacePressed' will have an empty 'EventArgs'.
    public event EventHandler OnSpacePressed;
    /*
    * To create an 'EventHandler' with a non empty 'EventArgs', a class should be created
    * and used as a generic parameter for the 'EventHandler' keyword.
    */
    public event EventHandler<OnLeftMousePressedEventArgs> OnLeftMousePressed;
    public class OnLeftMousePressedEventArgs : EventArgs {
        public int clickCount;
    }
    private int clickCount;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            /*
            * Checking if 'OnSpacePressed' has subscribers (not null) before firing it,
            * because if an event gets fired without having any, a 'NullReferenceException'
            * error occurs.
            */
            /* 
            * Tip: This is a compact way of writing: 'if (OnSpacePressed != null)
            * {OnSpacePressed(this, EventArgs.Empty)}'
            */
            OnSpacePressed?.Invoke(this, EventArgs.Empty);
        }
        if (Input.GetMouseButtonDown(0)){
            clickCount++;
            OnLeftMousePressed?.Invoke(this, new OnLeftMousePressedEventArgs { clickCount = clickCount});
        }
    }

}