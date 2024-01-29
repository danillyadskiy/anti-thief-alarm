using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Door : MonoBehaviour
{
    public readonly int IsOpen = Animator.StringToHash(nameof(IsOpen));

    [SerializeField] private Animator _animator;
    [SerializeField] private DoorTrigger _doorTrigger;

    private void OnEnable()
    {
        _doorTrigger.Entered += Open;
        _doorTrigger.Exited += Close;
    }

    private void OnDisable()
    {
        _doorTrigger.Entered -= Open;
        _doorTrigger.Exited -= Close;
    }
    
    private void Open()
    {
        _animator.SetBool(IsOpen, true);
    }

    private void Close()
    {
        _animator.SetBool(IsOpen, false);
    }
}
