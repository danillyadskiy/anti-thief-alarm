using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Door : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    
    public void Open()
    {
       _animator.SetBool("IsOpen", true);
    }

    public void Close()
    {
        _animator.SetBool("IsOpen", false);
    }
}
