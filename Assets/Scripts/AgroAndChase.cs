using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgroAndChase : MonoBehaviour
{
    public GameObject player;
    public float pursuitDistance = 5f;
    public float pursuitSpeed = 2f;
    
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
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
