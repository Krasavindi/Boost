using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float thrustSpeed = 800;
    [SerializeField] float rotationSpeed = 100;
    [SerializeField] ParticleSystem mainThruster;
    Rigidbody myRigidbody;
    
    [SerializeField] AudioSource myAudioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        mainThruster.Play();
       
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotating();
    }
    private void ProcessThrust()
    {
        Thrusting();
    }
    private void ProcessRotating()
    {
        if(Input.GetKey(KeyCode.A))
        {
            RotateLeft();
        }
        else if(Input.GetKey(KeyCode.D))
        {
            RotateRight();
        }
    }

    

    private void RotateRight()
    {
        myRigidbody.freezeRotation = true;
        transform.Rotate(-Vector3.forward * rotationSpeed * Time.deltaTime);
        myRigidbody.freezeRotation = false;
    }
    private void RotateLeft()
    {
        myRigidbody.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        myRigidbody.freezeRotation = false;
    }
    private void Thrusting()
    {
        if(Input.GetKey(KeyCode.Space))
        {
        if(!mainThruster.isPlaying)
        {
            mainThruster.Play();
        }
        
        myRigidbody.AddRelativeForce(Vector3.up * thrustSpeed * Time.deltaTime);
        if (!myAudioSource.isPlaying)
        {
            myAudioSource.Play();
        }
        }
        else
        {
            myAudioSource.Stop();
            mainThruster.Stop();
        }
    }
    public void StopThrusting()
    {
        myAudioSource.Stop();
    }

}
