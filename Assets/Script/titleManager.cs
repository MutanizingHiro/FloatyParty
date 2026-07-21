using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class titleManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip system;
    public GameObject imageObj1;

    public void ClickUI1()
    {
        audioSource.PlayOneShot(system);
        Invoke(nameof(LoadScene), 0.3f);
        
    }
    void LoadScene()
    {
        SceneManager.LoadScene("MainGame");
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
