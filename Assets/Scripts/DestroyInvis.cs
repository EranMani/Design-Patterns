using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyInvis : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        // Work only on object with renderer component
        //Destroy(this.gameObject);

        this.gameObject.SetActive(false);
    }
}
