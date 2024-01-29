using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    private const float Speed = 0.5f;

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AlarmTrigger _alarmTrigger;

    private IEnumerator _coroutine;

    private float VolumeDelta => Time.deltaTime * Speed;
    
    private void OnEnable()
    {
        _alarmTrigger.Entered += TurnOn;
        _alarmTrigger.Exited += TurnOff;
    }

    private void OnDisable()
    {
        _alarmTrigger.Entered -= TurnOn;
        _alarmTrigger.Exited -= TurnOff;
    }

    private void TurnOn()
    {
        RunCoroutine(MakeSoundLouder());
    }

    private void TurnOff()
    {
        RunCoroutine(MakeSoundQuieter());
    }

    private IEnumerator MakeSoundLouder()
    {
        float maxVolume = 1.0f;
        
        while (_audioSource.volume < maxVolume)
        {
            _audioSource.volume += VolumeDelta;
            yield return null;
        }
    }

    private IEnumerator MakeSoundQuieter()
    {
        float minVolume = 0.0f;

        while (_audioSource.volume > minVolume)
        {
            _audioSource.volume -= VolumeDelta;
            yield return null;
        }
    }
    
    private void RunCoroutine(IEnumerator coroutine)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
        
        _coroutine = coroutine;
        StartCoroutine(_coroutine);
    }
}
