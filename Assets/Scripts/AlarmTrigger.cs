using System;
using UnityEngine;

public class AlarmTrigger : MonoBehaviour
{
    public event Action Entered;
    public event Action Exited;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Thief>(out _))
            Entered?.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Thief>(out _))
            Exited?.Invoke();
    }
}
