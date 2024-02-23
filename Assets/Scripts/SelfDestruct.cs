using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    //script per eliminare le vfx che si generano al posto dei gameobject distrutti, da collegare ai loro ParticlesEffect
    void Start()
    {
        Destroy(gameObject, 1f); //l'ggetto viene distrutto entro 2 secondi
    }                            //gameObject con g minuscola per differenziare dalla funzione GameObject
}
