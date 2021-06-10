using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private void OnEnable()
    {
        Events.current.openDoorByTrigger += OpenDoor;
        Events.current.closeDoorByTrigger += CloseDoor;
    }

    private void OnDisable()
    {
        Events.current.openDoorByTrigger -= OpenDoor;
        Events.current.closeDoorByTrigger -= CloseDoor;
    }

    void OpenDoor()
    {
        this.GetComponent<MeshRenderer>().enabled = false;
        this.GetComponent<Collider>().enabled = false;
    }

    void CloseDoor()
    {
        StartCoroutine(CloseDoorCoroutine());
    }

    IEnumerator CloseDoorCoroutine()
    {
        yield return new WaitForSeconds(5f);
        this.GetComponent<MeshRenderer>().enabled = true;
        this.GetComponent<Collider>().enabled = true;
    }
}
