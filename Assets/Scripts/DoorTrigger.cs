using System;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public event Action TriggerEntered;
    public event Action TriggerExited;
    
    private void OnTriggerEnter(Collider other)
    {
        TriggerEntered?.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        TriggerExited?.Invoke();
    }
}
