using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Drive : MonoBehaviour
{
    public float speed = 10.0f;
    public GameObject bulletPrefab;
    public Slider healthBar;

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

        Vector3 screenPos = Camera.main.WorldToScreenPoint(this.transform.position) + 
                            new Vector3(0, -48, 0);
        healthBar.transform.position = screenPos;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Asteroid")
        {
            healthBar.value -= 30;
            if (healthBar.value <= 0)
            {
                Destroy(healthBar.gameObject, 0.1f);
                Destroy(this.gameObject, 0.1f);
            }
        }
    }
}