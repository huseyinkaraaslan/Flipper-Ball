using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    bool gamePause = false;
    public GameObject playButtonImage, pauseButtonImage;
    public GameObject pauseScreen,gameScreen;

    private void Start()
    {
        gameScreen.SetActive(true);
        pauseButtonImage.SetActive(true);
        playButtonImage.SetActive(false);
        pauseScreen.SetActive(false);
    }

    public void pauseButton()
    {
        if (!(gamePause))
        {
            Time.timeScale = 0f;
            pauseButtonImage.SetActive(false);
            gameScreen.SetActive(false);
            pauseScreen.SetActive(true);
            playButtonImage.SetActive(true);
            
            gamePause = true;
        }
        else if (gamePause)
        {
            Time.timeScale = 1f;
            playButtonImage.SetActive(false);
            pauseScreen.SetActive(false);
            gameScreen.SetActive(true);
            pauseButtonImage.SetActive(true);

            gamePause = false;
        }
    }

    public void nextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void back2Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
