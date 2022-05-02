using UnityEngine;

public class DelegatesExample : MonoBehaviour
{

    [SerializeField] private ActionOnTimer _actionOnTimer;

    void Start()
    {
        _actionOnTimer.SetTimer(1f, () => { Debug.Log("Timer complete!"); });
    }

}