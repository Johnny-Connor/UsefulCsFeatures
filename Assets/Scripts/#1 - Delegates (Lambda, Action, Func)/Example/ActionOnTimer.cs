/*
* How would you check 'IsTimerComplete()' in another class in a modular way? That is, without
* having to rely on an auxiliar variable in the other class solely created to prevent the
* check condition from being met in every frame, like in the following code:
* if (IsTimerComplete() && !hasTimerEnded){hasTimerEnded = true}')?
* Answer: With delegates! With them, you can easily create reusable codes, which are crucial
* to dramatically increase your development speed!
*/
using System;
using UnityEngine;

public class ActionOnTimer : MonoBehaviour
{

    private Action _timerCallBack;
    private float _timer;

    public void SetTimer(float _timer, Action _timerCallBack){
        this._timer = _timer;
        this._timerCallBack = _timerCallBack;
    }

    private void Update()
    {
        if (_timer > 0f){
            _timer -= Time.deltaTime;
            if (IsTimerComplete()){
                _timerCallBack();
            }
        }
    }

    public bool IsTimerComplete(){
        return _timer <= 0f;
    }

}