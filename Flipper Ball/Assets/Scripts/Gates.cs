using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gates : MonoBehaviour
{
    public GameObject playerGate,playerLamb, rivalGate,rivalLamb,tempPosition;
    Rigidbody rb;
    public bool level1,level2,level3;
    AudioSource audioSource;
    public AudioClip teleport, outTeleport;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = gameObject.GetComponent<Rigidbody>();
        level1 = false;
        level2 = false;
        level3 = false;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("level1"))
        {
            level1 = true;
            level2 = false;
            level3 = false;
        }
        else if (collision.gameObject.CompareTag("level2"))
        {
            level1 = false;
            level2 = true;
            level3 = false;
        }
        else if (collision.gameObject.CompareTag("level3"))
        {
            level1 = false;
            level2 = false;
            level3 = true;
        }


        if (collision.gameObject.CompareTag("playerGate"))
        {
            gameObject.transform.position = tempPosition.transform.position;
            audioSource.PlayOneShot(teleport);
            StartCoroutine(Hit());   
        }
        else if (collision.gameObject.CompareTag("rivalGate"))
        {
            gameObject.transform.position = tempPosition.transform.position;
            audioSource.PlayOneShot(teleport);
            StartCoroutine(Hit());
            
        }
    }

    IEnumerator Hit()
    {
        int tempValue = Random.Range(1, 3);
        if(tempValue == 1)
        {
            StartCoroutine(changePlayerColor());
            playerGate.GetComponent<Collider>().enabled = false;
            
        }
        else if (tempValue == 2)
        {
            StartCoroutine(changeRivalColor());
            rivalGate.GetComponent<Collider>().enabled = false;
        }

        yield return new WaitForSeconds(2f);
        switch (tempValue)
        {
            case 1:
                gameObject.transform.position = playerGate.transform.position;

                if (level1)
                {
                    audioSource.PlayOneShot(outTeleport);
                    rb.AddForce(Vector3.forward / 15);
                }

                else if(level2 || level3)
                {
                    audioSource.PlayOneShot(outTeleport);
                    rb.AddForce(Vector3.left / 15);
                }
                break;

            case 2:
                gameObject.transform.position = rivalGate.transform.position;
                if (level1)
                {
                    audioSource.PlayOneShot(outTeleport);
                    rb.AddForce(Vector3.forward / -15);
                }
                
                else if (level2 || level3)
                {
                    audioSource.PlayOneShot(outTeleport);
                    rb.AddForce(Vector3.left / -15);
                }
                break;
        }
        playerGate.GetComponent<Collider>().enabled = true;
        rivalGate.GetComponent<Collider>().enabled = true;
    }

    IEnumerator changePlayerColor()
    {
        playerLamb.GetComponent<Renderer>().material.color = Color.green;
        yield return new WaitForSeconds(.5f);
        playerLamb.GetComponent<Renderer>().material.color = Color.white;
        yield return new WaitForSeconds(.5f);
        playerLamb.GetComponent<Renderer>().material.color = Color.green;
        yield return new WaitForSeconds(.5f);
        playerLamb.GetComponent<Renderer>().material.color = Color.white;
    }

    IEnumerator changeRivalColor()
    {
        rivalLamb.GetComponent<Renderer>().material.color = Color.green;
        yield return new WaitForSeconds(.5f);
        rivalLamb.GetComponent<Renderer>().material.color = Color.white;
        yield return new WaitForSeconds(.5f);
        rivalLamb.GetComponent<Renderer>().material.color = Color.green;
        yield return new WaitForSeconds(.5f);
        rivalLamb.GetComponent<Renderer>().material.color = Color.white;
    }
}
