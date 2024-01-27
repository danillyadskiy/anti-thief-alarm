using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    private const float Speed = 0.5f;

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AlarmTrigger _alarmTrigger;

    private bool _isWorking;

    private void OnEnable()
    {
        _alarmTrigger.TriggerEntered += TurnOn;
        _alarmTrigger.TriggerExited += TurnOff;
    }

    private void OnDisable()
    {
        _alarmTrigger.TriggerEntered -= TurnOn;
        _alarmTrigger.TriggerExited -= TurnOff;
    }

    private void Start()
    {
        StartCoroutine(MakeSound());
    }

    private void TurnOn()
    {
        _isWorking = true;
    }

    private void TurnOff()
    {
        _isWorking = false;
    }

    private IEnumerator MakeSound()
    {
        float volumeDelta = Time.deltaTime * Speed;
        
        while (true)
        {
            if (_isWorking)
                _audioSource.volume += volumeDelta;
            else
                _audioSource.volume -= volumeDelta;
            
            yield return null;
        }
    }
}
