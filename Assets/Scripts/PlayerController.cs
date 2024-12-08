using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rigidbody2d;

    public float speed;
    public float speedIncreaseRate;
    public GameObject pausePanel;
    public GameObject winPanel;
    public GameObject losePanel;
    float speedMod; //mod incremented to provide build up to max speed
    bool paused;
    bool gameOver = false; //used to prevent movement during game won/loss screens

    public CameraShake cameraShake;


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

    void togglePause()
    {
        paused = !paused;

        if (paused)
        {
            if (pausePanel != null)
            {
                pausePanel.SetActive(true);
            }
        }
        else
        {
            if (pausePanel != null)
            {
                pausePanel.SetActive(false);            
            }
        }
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameOver == false)
            {
                togglePause();
            }
        }

        if (paused || gameOver)
        {

            rigidbody2d.velocity = Vector2.zero;
            return;
        }

        Vector2 moveDirection = Vector2.zero;
       
        if (Input.GetKey(KeyCode.Space)) //spacebar is being pressed
        {
            Debug.Log("Spacebar being pressed");
            rigidbody2d.velocity = Vector2.zero;
        }
        else
        {
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) // input is positive moving right
            {
                modspeed();
                moveDirection.x = speed * speedMod;
            }
            else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) // input is nevative
            {
                modspeed();
                moveDirection.x = -speed * speedMod;
            }

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) //input is pos
            {
                modspeed();
                moveDirection.y = speed * speedMod;
            }
            else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) //input is pos
            {
                modspeed();
                moveDirection.y = -speed * speedMod;
            }

            if (moveDirection == Vector2.zero)
            {
                rigidbody2d.velocity = Vector2.zero;
                speedMod = 0.0f;
            }
            else
            {
                rigidbody2d.velocity = moveDirection;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Door") //if player overlaps winning door
        {
            if (gameOver) //preventing unintentional double scenario trigger
            {
                return;
            }

            Debug.Log("Level Complete"); //debug
            winPanel.SetActive(true); //setting win panel to visible
            gameOver = true; //preventing extra trips of screen load
        }
        else if (other.tag == "Enemy") //if player overlaps enemy
        {
            if (gameOver) //preventing unintentional enemy trigger after win
            {
                return;
            }

            Debug.Log("Not a Winner :D"); //debug
            losePanel.SetActive(true); //lose panel
            gameOver = true; //stopping player movement/preventing re-trip of screens
            StartCoroutine(cameraShake.Shake(.15f, .05f)); // camera shake
        }
    }
}
