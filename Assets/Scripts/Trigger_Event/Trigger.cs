using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Events.current.OpenDoorByTrigger();
    }

    private void OnTriggerExit(Collider other)
    {
        Events.current.CloseDoorByTrigger();
    }
}
