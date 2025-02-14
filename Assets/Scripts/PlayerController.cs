using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public Heart heartScript;
    
    public Animator animator;
    
    public Animator animator2;

    public float moveSpeed;

    Camera mainCam;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");

        Vector2 destination = new Vector2(x, y) * moveSpeed * Time.deltaTime;

        transform.Translate(destination);
        animator2.SetFloat("IsWalking", (x + y + 0.1f) / 1.5f);


    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "LeftDoor")
        {
            animator.Play("FLash");
            transform.Translate(-8, 0, 0);
            mainCam.transform.Translate(-20, 0, 0);
        }

        if (other.gameObject.tag == "RightDoor")
        {
            animator.Play("FLash");
            transform.Translate(8, 0, 0);
            mainCam.transform.Translate(20, 0, 0);
        }

        if (other.gameObject.tag == "UpDoor")
        {
            animator.Play("FLash");
            transform.Translate(0, 8, 0);
            mainCam.transform.Translate(0, 12, 0);
        }

        if (other.gameObject.tag == "DownDoor")
        {
            animator.Play("FLash");
            transform.Translate(0, -8, 0);
            mainCam.transform.Translate(0, -12, 0);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "enemy") 
        {
            heartScript.health -= 1;
        }
    }
}
