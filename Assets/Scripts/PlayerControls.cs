using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using static UnityEngine.ParticleSystem;

public class PlayerControls : MonoBehaviour
{
    [Header("Key Bindings")]
    [SerializeField] InputAction movement;
    [SerializeField] InputAction fire;
    [Header("Weapon Array")]
    [Tooltip("Add here New Weapontype Array")]
    [SerializeField] GameObject[] lasers;
    [Header("General Settings")]
    [Tooltip("Moving on Screen Speed")][SerializeField] float controlSpeed = 20f;
    [Tooltip("Screen Limit")][SerializeField] float xRange = 11f;
    [Tooltip("Screen Limit")][SerializeField] float yRange = 7f;
    [Header("Flight Turning Angle")]
    [SerializeField] float rotationFactor = 1f;
    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float controlPitchFactor = -10f;
    [SerializeField] float controlRollFactor = -20f;
    [SerializeField] float positionYawFactor = 3f;

    float xThrow, yThrow;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnEnable()
    {
        movement.Enable();
        fire.Enable();
    }

    void OnDisable()
    {
        movement.Disable();
        fire.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        ProcessFiring();
    }

    void ProcessRotation()
    {
        float pitchPositionTo = transform.localPosition.y * positionPitchFactor;
        float pitchControlThrow = yThrow * controlPitchFactor;

        float pitch = pitchPositionTo + pitchControlThrow; //BECCHEGGIO asse Y
        float yaw = transform.localPosition.x * positionYawFactor;   //IMBARDATA asse X
        float roll = xThrow * controlRollFactor;  //ROLLIO asse Z

        //transform.localRotation = Quaternion.Euler(pitch, yaw, roll); formula breve, utile con joystick
        Quaternion targetRotation = Quaternion.Euler(pitch, yaw, roll);
        transform.localRotation = Quaternion.RotateTowards(transform.localRotation, targetRotation, rotationFactor);
        //formula per Tastiera così evita di essere troppo legnoso il movimento UTILIZZANDO IL NUOVO INPUT SYSTEM
    }

    void ProcessTranslation()
    {
        xThrow = movement.ReadValue<Vector2>().x;//".x / .y" indica su quale asse  leggere.
        yThrow = movement.ReadValue<Vector2>().y;

        float xOffset = xThrow * Time.deltaTime * controlSpeed;
        float yOffset = yThrow * Time.deltaTime * controlSpeed;

        float rawXPos = transform.localPosition.x + xOffset;
        float rawYPos = transform.localPosition.y + yOffset;

        float limitXPos = Mathf.Clamp(rawXPos, -xRange, xRange); //per limitare movimenti e non uscire da visuale
        float limitYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition = new Vector3(limitXPos, limitYPos, transform.localPosition.z);
        //z non serve in questo caso
    }

    void ProcessFiring()
    {
        if (fire.ReadValue<float>() > 0.5 )
        {
            SetLaserActive(true);
        }
        else
        {
            SetLaserActive(false);
        }
    }

    void SetLaserActive(bool isActive)
    {
        foreach (GameObject laser in lasers)
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActive;
        }
    }



}
