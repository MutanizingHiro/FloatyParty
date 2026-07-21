using UnityEngine;
using UnityEngine.SceneManagement;
public class Manager : MonoBehaviour
{
    public float waitingSeconds;
    public AudioSource audioSource;

    public AudioClip system;

    public GameObject imageObj1;
    public GameObject imageObj2;

    public void RetryButton()
    {
        audioSource.PlayOneShot(system);
        Invoke(nameof(ToMainGame), waitingSeconds);
        
    }

    public void QuitButton()
    {
        audioSource.PlayOneShot(system);
        Invoke(nameof(ToTitleScreen), waitingSeconds);
       
    }
    void ToMainGame()
    {
        GameManagerScript.instance.StartCoroutine(GameManagerScript.instance.GameOverScreenToMainGame());
    }

    void ToTitleScreen()
    {
        GameManagerScript.instance.StartCoroutine(GameManagerScript.instance.GameOverScreenToTitleScreen());
    }

    void Start()
    {
        RankingManager.SaveScore(Sample.ScoreToGo);
    }
}
