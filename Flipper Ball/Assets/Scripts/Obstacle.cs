using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip slingshotSound,obstacleSound,tempObstacleSound,minusScore,plusScore;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Destroy(transform.parent.gameObject);
        }


        if (collision.gameObject.CompareTag("slingshots"))
        {
            audioSource.PlayOneShot(slingshotSound);
        }

        else if (collision.gameObject.CompareTag("capsule"))
        {
            audioSource.PlayOneShot(obstacleSound);
        }
        
        else if (collision.gameObject.CompareTag("tempObstacle"))
        {
            audioSource.PlayOneShot(tempObstacleSound);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("playerGoal"))
        {
            audioSource.PlayOneShot(minusScore);
        }
        else if (other.gameObject.CompareTag("rivalGoal"))
        {
            audioSource.PlayOneShot(plusScore);
        }
    }
}
