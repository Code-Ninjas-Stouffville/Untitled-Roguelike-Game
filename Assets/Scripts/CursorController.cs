using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    
    public GameObject projectile;
    
    private float reload;

    public int enemyCount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Camera.main.ScreenToWorldPoint(Input.mousePosition), -Vector3.forward);
        transform.rotation = Quaternion.Euler(0,0,-transform.eulerAngles.z);
        if (Input.GetKey("space"))
        {
            if (reload <= 0 && enemyCount <= 3)
            {
                Instantiate(projectile, transform.position, transform.rotation);
                reload = (1 - enemyCount * 0.2f);
            }
            else if (reload <= 0 && enemyCount > 3)
            {
                Instantiate(projectile, transform.position, transform.rotation);
                reload = 0.2f;
            }
        }

        if (reload > 0)
        {
            reload -= Time.deltaTime;
        }
    }
}
