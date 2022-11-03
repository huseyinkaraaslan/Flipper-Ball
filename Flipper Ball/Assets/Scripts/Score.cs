using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public int playerScoreValue;
    public int rivalScoreValue;
    public Text playerScoreText, rivalScoreText, winnerText;
    public GameObject ballRivalStartPoint, ballPlayerStartPoint,loseScreen,winScreen;
    Rigidbody rb;

    void Start()
    {
        loseScreen.SetActive(false);
        winScreen.SetActive(false);
        rb = gameObject.GetComponent<Rigidbody>();
        playerScoreValue = 0;
        rivalScoreValue = 0;
    }

    void Update()
    {
        if(playerScoreValue == 7)
        {
            winnerText.color = Color.green;
            winnerText.text = "You Win";
            winScreen.SetActive(true);
            gameObject.SetActive(false);
        }
        else if(rivalScoreValue == 7)
        {
            winnerText.color = Color.red;
            winnerText.text = "You Lost";
            loseScreen.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "playerGoal")
        {
            rivalScoreValue++;
            rivalScoreText.text = rivalScoreValue.ToString();
            gameObject.transform.position = ballPlayerStartPoint.transform.position;
        }
        else if(other.gameObject.tag == "rivalGoal")
        {
            playerScoreValue++;
            playerScoreText.text = playerScoreValue.ToString();
            gameObject.transform.position = ballRivalStartPoint.transform.position;
        }
    }
}
