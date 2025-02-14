using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EnemyController : MonoBehaviour
{
    public float speed = 5;
    public float hp = 3;
    public bool boss;
    // Start is called before the first frame update
    void Start()
    {
        transform.GetComponent<Rigidbody2D>().velocity = new Vector2 (speed,speed);
    }

    // Update is called once per frame
    void Update()
    {

        //transform.Translate(speed * Time.deltaTime, 0, 0);
        if (hp == 0) 
        {
            if (boss == true)
            {
                SceneManager.LoadScene("You Win");
            }
            GameObject.Find("shoot").GetComponent<CursorController>().enemyCount += 1;
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Respawn")
        {
            hp -= 1;
            Destroy(other);
        }
    }
}