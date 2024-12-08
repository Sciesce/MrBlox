using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgroAndChase : MonoBehaviour
{
    public GameObject player; //player ref 
    public float pursuitDistance = 5f;  //max distance to detect/follow
    public float pursuitSpeed = 2f;  //speed to follow
    
    private Rigidbody2D rb; //rb ref

    void Start() //calling at start before first frame
    {
        rb = GetComponent<Rigidbody2D>(); //setting rb ref on play to be used on update
    }

    void FixedUpdate() //calling each frame at fixed rate
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position); //checking distance to player

        if (distanceToPlayer <= pursuitDistance) //if distance to player is less than max pursuit distance
        {
            Vector2 directionToPlayer = (player.transform.position - transform.position).normalized; //determining direction to player
            rb.velocity = directionToPlayer * pursuitSpeed; //setting pursuit in direction of player
        }
        else
        {
            rb.velocity = Vector2.zero; //standing still
        }
    }
}
