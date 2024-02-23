using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    int hits = 0;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag != "Hit")
        { 
        hits = hits + 1;
        Debug.Log("Are u Happy? u smashed my face:" + hits );
        }
    }
}
