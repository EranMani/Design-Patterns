using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class UnityGameObjectEvent : UnityEvent<GameObject> { }

public class EventListener : MonoBehaviour
{
    public Event gEvent;
    public UnityGameObjectEvent response = new UnityGameObjectEvent();
    //public UnityEvent response;

    private void OnEnable()
    {
        gEvent.Register(this);
    }

    private void OnDisable()
    {
        gEvent.Unregister(this);
    }

    public void OnEventOccurs(GameObject go)
    {
        response.Invoke(go);
    }
}
