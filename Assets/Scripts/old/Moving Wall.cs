using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWall : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) 
    {
            if (other.gameObject.tag == "Player")
            {       
            transform.Translate (3, 0, 0);
            }
       
    }
}
