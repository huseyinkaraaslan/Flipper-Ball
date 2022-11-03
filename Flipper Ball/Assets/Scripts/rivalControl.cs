using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rivalControl : MonoBehaviour
{
    public Rigidbody leftFlipper,rightFlipper;
    private float power = 1000;
    AudioSource audioSource;
    public AudioClip flipperSound;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "rivalLeftFlipper")
        {
            Hit(leftFlipper);
            audioSource.PlayOneShot(flipperSound);
        }
        else if (other.gameObject.tag == "rivalRightFlipper")
        {
            Hit(rightFlipper);
            audioSource.PlayOneShot(flipperSound);
        }
    }

    private void Hit(Rigidbody rb)
    {
        rb.AddForce(Vector3.forward * -power);
    }
}
