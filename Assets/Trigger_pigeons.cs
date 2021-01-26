using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_pigeons : MonoBehaviour
{
    public AK.Wwise.Event pigeonsEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pigeonsEvent.Post(gameObject);
            Destroy(gameObject);
        }
    }
}
