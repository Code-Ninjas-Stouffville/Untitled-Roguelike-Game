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

    public bool invincible;

    public float alphaValue = 0.5f;  // Set the alpha value here (between 0 and 1)

    public SpriteRenderer spriteRenderer;

    public Color currentColor;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
        invincible = true;
        Invoke("UnInvince", 1.5f);

        currentColor = spriteRenderer.color;

        currentColor.a = alphaValue;
    }

    // Update is called once per frame
    void Update()
    {
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");

        Vector2 destination = new Vector2(x, y) * moveSpeed * Time.deltaTime;

        transform.Translate(destination);
        animator2.SetFloat("IsWalking", (x + y + 0.1f) / 1.5f);

        if (invincible)
        {
            alphaValue = 0.5f;
            currentColor.a = alphaValue;
            spriteRenderer.color = currentColor;
        }
        else
        {
            alphaValue = 1;
            currentColor.a = alphaValue;
            spriteRenderer.color = currentColor;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "LeftDoor")
        {
            animator.Play("FLash");
            transform.Translate(-8, 0, 0);
            mainCam.transform.Translate(-20, 0, 0);
            invincible = true;
            Invoke("UnInvince", 1);
        }

        if (other.gameObject.tag == "RightDoor")
        {
            animator.Play("FLash");
            transform.Translate(8, 0, 0);
            mainCam.transform.Translate(20, 0, 0);
            invincible = true;
            Invoke("UnInvince", 1);
        }

        if (other.gameObject.tag == "UpDoor")
        {
            animator.Play("FLash");
            transform.Translate(0, 8, 0);
            mainCam.transform.Translate(0, 12, 0);
            invincible = true;
            Invoke("UnInvince", 1);
        }

        if (other.gameObject.tag == "DownDoor")
        {
            animator.Play("FLash");
            transform.Translate(0, -8, 0);
            mainCam.transform.Translate(0, -12, 0);
            invincible = true;
            Invoke("UnInvince", 1);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "enemy" && invincible == false) 
        {
            heartScript.health -= 1;
            invincible = true;
            Invoke("UnInvince", 1);
        }
    }

    void UnInvince()
    {
        invincible = false;
    }
}
