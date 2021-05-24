using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnd : MonoBehaviour
{
    public AudioSource endSound;
    public void GameOverScreen()
    {
        gameObject.SetActive(true);
        endSound.Play();
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("Game");
        
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
