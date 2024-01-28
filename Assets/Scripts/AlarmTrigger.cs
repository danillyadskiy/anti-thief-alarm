using System;
using UnityEngine;

public class AlarmTrigger : MonoBehaviour
{
    public event Action TriggerEntered;
    public event Action TriggerExited;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Thief>(out _))
            TriggerEntered?.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Thief>(out _))
            TriggerExited?.Invoke();
    }
}
