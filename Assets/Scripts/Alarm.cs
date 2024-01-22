using UnityEngine;

public class Alarm : MonoBehaviour
{
    private const float Speed = 0.5f;
    
    [SerializeField] private AudioSource _audioSource;

    private bool _isWorking;

    public void TurnOn()
    {
        _isWorking = true;
    }

    public void TurnOff()
    {
        _isWorking = false;
    }

    private void Update()
    {
        if (_isWorking)
            _audioSource.volume = Mathf.Clamp01(_audioSource.volume + Time.deltaTime * Speed);
        else
            _audioSource.volume = Mathf.Clamp01(_audioSource.volume - Time.deltaTime * Speed);
    }
}
