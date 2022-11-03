using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{
    public Rigidbody leftFlipper,rightFlipper;
    private float power = 800;
    bool leftFlipperButton, rightFlipperButton;
    AudioSource audioSource;
    public AudioClip flipperSound;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(leftFlipperButton)
        {
            Hit(leftFlipper);
            audioSource.PlayOneShot(flipperSound);
            leftFlipperButton = false;
        }
        else if(rightFlipperButton)
        {
            Hit(rightFlipper);
            audioSource.PlayOneShot(flipperSound);
            rightFlipperButton = false;
        }
        
    }

    private void Hit(Rigidbody rb)
    {
        rb.AddForce(Vector3.forward * power);
    }

    public void leftButton()
    {
        leftFlipperButton = true;
    }

    public void rightButton()
    {
        rightFlipperButton = true;
    }


    
}
