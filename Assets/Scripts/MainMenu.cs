using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   
    void resetTimeScale() //resetting time scale to normal time in case of any paused mechanic
    {
        Time.timeScale = 1;
    }
    // Start is called before the first frame update
    public void PlayGame() //loads next scene, can be used from main menu to level 1 or any "next level" button
    {
        resetTimeScale(); 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }   

    public void QuitGame() //closing the application.
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void RestartLevel() //reloads current level 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        resetTimeScale();
    }

    public void OpenSelectedLevel(int index) //level select functionality
    {
        SceneManager.LoadScene(index);
        resetTimeScale();
    }

    public void RestartGame() //reloads to main menu
    {
        SceneManager.LoadScene(0);
        resetTimeScale();
    }
}
