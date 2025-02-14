using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    public float bulletSpeed;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyBullet", 3);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 destination = new Vector2(0, bulletSpeed) * Time.deltaTime;
        gameObject.transform.Translate(-destination);
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag != "Player" && other.gameObject.tag != "Respawn" && other.gameObject.tag != "LeftDoor" && other.gameObject.tag != "RightDoor" && other.gameObject.tag != "UpDoor" && other.gameObject.tag != "DownDoor")
        {
            DestroyBullet();
        }
    }
}
