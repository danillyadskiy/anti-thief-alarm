using System;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public event Action Entered;
    public event Action Exited;
    
    private void OnTriggerEnter(Collider other)
    {
        Entered?.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        Exited?.Invoke();
    }
}
