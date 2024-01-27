using System;
using UnityEngine;

public class AlarmTrigger : MonoBehaviour
{
    public event Action TriggerEntered;
    public event Action TriggerExited;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Thief>())
            TriggerEntered?.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Thief>())
            TriggerExited?.Invoke();
    }
}
