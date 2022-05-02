using System;
using UnityEngine;

public class Subscriber : MonoBehaviour
{

    [SerializeField] private Publisher _publisher;

    void Start()
    {
        /*
        * Adding the function 'Testing_OnSpacePressed' to the event 'OnSpacePressed' from
        * 'Publisher.cs'.
        * Whenever the event is invoked, every function attached to it will trigger.
        */
        _publisher.OnSpacePressed += Testing_OnSpacePressed;
        _publisher.OnLeftMousePressed += Testing_OnLeftMousePressed;
    }

    private void Testing_OnSpacePressed(object sender, EventArgs e){
        Debug.Log("Space!");
    }

    private void Testing_OnLeftMousePressed(object sender, Publisher.OnLeftMousePressedEventArgs e){
        Debug.Log("Clickcount: " + e.clickCount);
    }

}