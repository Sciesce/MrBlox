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
    float speedMod;
    bool paused;
    bool gameOver = false;


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
        if (other.tag == "Door")
        {
            Debug.Log("Level Complete");
            winPanel.SetActive(true);
            gameOver = true;
        }
        else if (other.tag == "Enemy")
        {
            Debug.Log("Not a Winner :D");
            losePanel.SetActive(true);
            gameOver = true;
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
