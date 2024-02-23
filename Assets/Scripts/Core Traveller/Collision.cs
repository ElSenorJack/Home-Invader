using UnityEngine;
using UnityEngine.SceneManagement;
public class collision : MonoBehaviour
{
    [SerializeField] AudioClip Fail;
    [SerializeField] AudioClip Success;
    [SerializeField] ParticleSystem FailParticle;
    [SerializeField] ParticleSystem SuccessParticle;

    new AudioSource audio;
    float LoadDelay = 2f;

    bool isTransitioning = false;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision other)
    {
        if (isTransitioning) { return; }
            switch (other.gameObject.tag)
            {
                case "Finish":
                    Debug.Log("You Made It!");
                    NextLevelSequence();
                    break;
                case "Friendly":
                    break;
                default:
                    Debug.Log("You Blew IT!!!");
                    CrashSequence();
                    break;
            }
    }
    void NextLevelSequence()
    {
        isTransitioning = true;
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", LoadDelay);
        SuccessParticle.Play();
        audio.PlayOneShot(Success);
    }
    void CrashSequence()
    {
        isTransitioning = true;
        GetComponent<Movement>().enabled = false;
        audio.PlayOneShot(Fail);
        FailParticle.Play();
        Invoke("ReloadLevel", LoadDelay);
    }
    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
       //SceneManager.LoadScene(currentSceneIndex + 1); <SEMPLICE PASSAGGIO A LIVELLO SUCCESSIVO,SE INTERESSA IGNORA SOTTO
        //VVV QUESTO PER RICOMINCIARE QUANDO I LIVELLI FINISCONO VVV
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)//se il prossimo numero è uguale al conteggio totale delle scene
        {
            nextSceneIndex = 0;                                         // allora la prossima scena sarà la "0"
        }
        SceneManager.LoadScene(nextSceneIndex);
    }
    void ReloadLevel()   
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; //Caching per estrapolare indice della scena e ripeterlo
        SceneManager.LoadScene(currentSceneIndex);
    }
}
