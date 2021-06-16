using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drive : MonoBehaviour
{
    public float speed = 10.0f;
    public GameObject bulletPrefab;

    void Update()
    {
        float translation = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        transform.Translate(translation, 0, 0);

        if (Input.GetKeyDown("space"))
        {
            GameObject bullet = Pool.singleton.Get("Bullet");
            if (bullet != null)
            {
                bullet.transform.position = this.transform.position;
                bullet.SetActive(true);
            }
        }
    }
}