using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour   
{
    Vector3 startingPoint;
    [SerializeField] Vector3 movementVector;
    [SerializeField] [Range(0,1)] float movementFactor;
    [SerializeField] float period = 2f;

    // Start is called before the first frame update
    void Start()
    {
        startingPoint = transform.position;       
    }

    // Update is called once per frame
    void Update()
    {                                               //Mathf.Epsilon serve per generare il numero più piccolo su unity
        const float Tau = Mathf.PI * 2;             //Tau vale 6,28. SEMPRE
        float cycles = Time.time / period;          //Riproduzione costante, più period è basso più è veloce
        if (period <= Mathf.Epsilon) { return; }    //Impedire che il valore sia 0 altrimenti si rischiano Crash
        float rawSinWave = Mathf.Sin(cycles * Tau); //Valore Oscillante tra -1 e 1

        movementFactor = (rawSinWave + 1f) / 2f;    //Con questa formula ^^ viene ricalcolato tra 0 e 1
        
        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPoint + offset;
    }
}
