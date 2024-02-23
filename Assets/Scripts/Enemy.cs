using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject Explosion; //sfx e vfx uniti da un Audio Source Component
    [SerializeField] GameObject hitVfx;
    [SerializeField] int ScoreValue = 10;
    [SerializeField] public int Hp = 5;
    [SerializeField] AudioClip DestroySFX;
    [SerializeField] float delay = 1f;
    new AudioSource audio;
    Scoreboard scoreBoard;
    void Start()
    {
        audio = GetComponent<AudioSource>();
        scoreBoard = FindObjectOfType<Scoreboard>();
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
        Invoke("LoadNextLevel", 120f);
    }
    void OnParticleCollision(GameObject other)
    {
        Scoring();

        if (Hp < 1)
        {
            KillEnemy();
        }
    }

    void Scoring()
    {
        Instantiate(hitVfx, transform.position, Quaternion.identity);
        scoreBoard.IncreaseScore(ScoreValue);
        Hp--;
    }

    void KillEnemy()
    {        
        Instantiate(Explosion, transform.position, Quaternion.identity);
        Destroy(gameObject, delay);
        audio.PlayOneShot(DestroySFX);
    }
    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
