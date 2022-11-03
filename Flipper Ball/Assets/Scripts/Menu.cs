using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject mainScreen,playScreen,optionsScreen,level2Lock,level3Lock;
    public Slider slider;
    AudioSource audioSource;
    public AudioClip menuButtonSound,lockedLevelSound;
    Score score;
    int level2Entry = 0 ,level3Entry = 0;

    private void Start()
    {
        level2Entry = PlayerPrefs.GetInt(nameof(level2Entry));
        level3Entry = PlayerPrefs.GetInt(nameof(level3Entry));

        audioSource = GetComponent<AudioSource>();
        mainScreen.SetActive(true);
        playScreen.SetActive(false);
        optionsScreen.SetActive(false);

        audioSource.volume = PlayerPrefs.GetFloat("audioVolume");
        slider.value = PlayerPrefs.GetFloat("audioVolume");

    }

    private void Update()
    {
        if (level2Entry == 1)
        {
            level2Lock.SetActive(false);
        }
        if (level3Entry == 1)
        {
            level2Lock.SetActive(false);
        }

        if (gameObject.GetComponent<Gates>().level1 & gameObject.GetComponent<Score>().playerScoreValue == 7)
        {
            level2Entry = 1;
            PlayerPrefs.SetInt(nameof(level2Entry), level2Entry);
        }
        else if (gameObject.GetComponent<Gates>().level2 & gameObject.GetComponent<Score>().playerScoreValue == 7)
        {
            level3Entry = 1;
            PlayerPrefs.SetInt(nameof(level3Entry), level3Entry);
        }
    }

    public void playButton()
    {
        audioSource.PlayOneShot(menuButtonSound);
        playScreen.SetActive(true);
        mainScreen.SetActive(false);
        optionsScreen.SetActive(false);
    }

    public void optionsButton()
    {
        audioSource.PlayOneShot(menuButtonSound);
        optionsScreen.SetActive(true);
        mainScreen.SetActive(false);
        playScreen.SetActive(false);
    }

    public void menuMusic(float value)
    {
        audioSource.volume = value;
        PlayerPrefs.SetFloat("audioVolume", audioSource.volume);
    }

    public void startLevel1()
    {
        audioSource.PlayOneShot(menuButtonSound);
        SceneManager.LoadScene("Level1");
        Time.timeScale = 1f;
    }
    public void startLevel2()
    {
        if (level2Entry == 1)
        {
            audioSource.PlayOneShot(menuButtonSound);
            SceneManager.LoadScene("Level2");
            Time.timeScale = 1f;
        }
        else
            audioSource.PlayOneShot(lockedLevelSound);
    }

    public void startLevel3()
    {
        if (level3Entry == 1)
        {
            audioSource.PlayOneShot(menuButtonSound);
            SceneManager.LoadScene("Level3");
            Time.timeScale = 1f;
        }
        else
            audioSource.PlayOneShot(lockedLevelSound);
    }


    public void back2Menu()
    {
        audioSource.PlayOneShot(menuButtonSound);
        mainScreen.SetActive(true);
        playScreen.SetActive(false);
        optionsScreen.SetActive(false);

    }

    public void quit()
    {
        audioSource.PlayOneShot(menuButtonSound);
        Application.Quit();
    }
}
