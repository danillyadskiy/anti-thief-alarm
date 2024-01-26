using System;
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
        while (true)
        {
            if (_isWorking)
                _audioSource.volume = Mathf.Clamp01(_audioSource.volume + Time.deltaTime * Speed);
            else
                _audioSource.volume = Mathf.Clamp01(_audioSource.volume - Time.deltaTime * Speed);
            
            yield return null;
        }
    }
}
