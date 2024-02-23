using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 750f;
    [SerializeField] float rotationThrust = 100f;
    [SerializeField] AudioClip Thrusters;
    [SerializeField] ParticleSystem RightParticle;
    [SerializeField] ParticleSystem LeftParticle;
    [SerializeField] ParticleSystem MainThrusterParticle;

    Rigidbody rb;
    new AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }
    }
    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ThrustLeft();
        }

        else if (Input.GetKey(KeyCode.D))
        {
            ThrustRight();
        }
        else
        {
            StopRotating();
        }
    }
    void StopThrusting()
    {
        MainThrusterParticle.Stop();
        audio.Stop();
    }
    void StartThrusting()
    {
        rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        if (!audio.isPlaying)
        {
            audio.PlayOneShot(Thrusters);
        }
        if (!MainThrusterParticle.isPlaying)
        {
            MainThrusterParticle.Play();
        }
    }
    void StopRotating()
    {
        RightParticle.Stop();
        LeftParticle.Stop();
    }
    void ThrustRight()
    {
        ApplyRotation(-rotationThrust);
        if (!LeftParticle.isPlaying)
        {
            LeftParticle.Play();
        }
    }
    void ThrustLeft()
    {
        ApplyRotation(rotationThrust);
        if (!RightParticle.isPlaying)
        {
            RightParticle.Play();
        }
    }
    void ApplyRotation(float rotationThisFrame)
    {
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
    }

}
