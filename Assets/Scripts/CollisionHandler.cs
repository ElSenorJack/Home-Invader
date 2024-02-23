using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    float LoadDelay = 1f;
    [SerializeField] GameObject Explosion;
    [SerializeField] AudioClip DestroySfx;
    new AudioSource audio;

    void OnTriggerEnter(Collider other)
    {
        CrashSequence();
    }
    void CrashSequence()
    {
        Instantiate(Explosion, transform.position, Quaternion.identity);
        GetComponent<PlayerControls>().enabled = false;   
        Invoke("ReloadLevel", LoadDelay);
        audio.PlayOneShot(DestroySfx);
        Destroy(gameObject, LoadDelay);
    }
    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
