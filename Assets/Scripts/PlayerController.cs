using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rigidbody2d;

    public float speed;
    public float speedIncreaseRate;
    float speedMod;

    void Start()
    {
        
    }

    void modspeed()
    {
        if (speedMod <= 1)
        {
            speedMod += speedIncreaseRate;
        }
        else
        {
            speedMod = 1;
        }
    }

    void Update()
    {
         if (Input.GetAxis("Jump") > 0) //spacebar is being pressed
        {
            Debug.Log("Spacebar being pressed");
            rigidbody2d.velocity = new Vector2(0.0f, 0.0f);
        }
        else
        {
            if (Input.GetAxis("Horizontal") > 0) // input is positive moving right
            {
                modspeed();
                rigidbody2d.velocity = new Vector2(speed * speedMod, 0f);
            }
            else if (Input.GetAxis("Horizontal") < 0) // input is nevative
            {
                modspeed();
                rigidbody2d.velocity = new Vector2(-speed * speedMod, 0f);
            }

            if (Input.GetAxis("Vertical") > 0) //input is pos
            {
                modspeed();
                rigidbody2d.velocity = new Vector2(0f, speed * speedMod);
            }
            else if (Input.GetAxis("Vertical") < 0) //input is pos
            {
                modspeed();
                rigidbody2d.velocity = new Vector2(0f, -speed * speedMod);
            }
            else if (Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0) //axis is zero
            {
                rigidbody2d.velocity = new Vector2(0f, 0f);
                speedMod = 0.0f;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Door")
        {
            Debug.Log("Level Complete");
        }
        else
        {
            Debug.Log("Not a Winner :D");
        }

    }
}
