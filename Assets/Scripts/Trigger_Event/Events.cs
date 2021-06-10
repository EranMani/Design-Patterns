using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Events : MonoBehaviour
{
    public static Events current;

    private void Awake()
    {
        current = this;
    }

    public event Action openDoorByTrigger;
    public event Action closeDoorByTrigger;

    public void OpenDoorByTrigger()
    {
        openDoorByTrigger();
    }

    public void CloseDoorByTrigger()
    {
        closeDoorByTrigger();
    }
}
