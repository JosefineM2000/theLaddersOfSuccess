using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver_CS : MonoBehaviour
{
    public static bool playerIsDead = false;
    public GameObject gameOverUI;
    public AudioSource sound1;
    public AudioSource sound2;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            PlayerDead();
        }
    }

    public void PlayerDead()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
        playerIsDead = true;
        sound2.Play();
        sound1.Pause();
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }

    public bool getStatus()
    {
        return playerIsDead;
    }
}
