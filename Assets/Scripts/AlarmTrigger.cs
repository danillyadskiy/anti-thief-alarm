using System;
using System.Collections;
using UnityEngine;

public class AlarmTrigger : MonoBehaviour
{
    [SerializeField] private Alarm _alarm;
    
    private void OnTriggerEnter(Collider other)
    {
        _alarm.TurnOn();
    }

    private void OnTriggerExit(Collider other)
    {
        _alarm.TurnOff();
    }
}
