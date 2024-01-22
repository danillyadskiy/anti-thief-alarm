using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private Door _door;

    private void OnTriggerEnter(Collider other)
    {
        _door.Open();
    }

    private void OnTriggerExit(Collider other)
    {
        _door.Close();
    }
}
