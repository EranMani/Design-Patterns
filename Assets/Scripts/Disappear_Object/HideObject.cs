using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HideObject : MonoBehaviour
{
    public static event Action hidePlayer;

    private void Start()
    {
        Destroy(this.gameObject);
    }

    private void OnDestroy()
    {
        hidePlayer?.Invoke();
    }
}
