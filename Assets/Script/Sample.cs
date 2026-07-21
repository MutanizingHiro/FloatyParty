using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class Sample : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip hit;
    public AudioClip shoot;
    public AudioClip system;

    public AudioClip seA1;
    public AudioClip seA2;
    public AudioClip seA3;
    public AudioClip seA4;
    public AudioClip se2;
    public AudioClip die;
    public AudioClip die2;
    public AudioClip die3;
    public AudioClip die4;
    public AudioClip se4;

    public Image imageB;
    public Sprite imageC;

    public GameObject imageCObj;
    public GameObject imageC2Obj;
    public GameObject imageC3Obj;
    public GameObject imageC4Obj;
    public GameObject imageD;
    bool fly = false;

    void Update()
    {
        if (fly)
        {
            imageD.transform.Translate(0, 300 * Time.deltaTime, 0);
        }
    }

    public TMP_Text scoreText;
    public void HIT()
    {
        audioSource.PlayOneShot(hit);
        score += 100; 
        scoreText.text = "Score : " + score;
    }

    public void SHOOT()
    {
        audioSource.PlayOneShot(shoot, 0.7f);
    }

    public void ClickA()
    {
        audioSource.PlayOneShot(seA1, 0.5f);
    }
    public void ClickA2()
    {
        audioSource.PlayOneShot(seA2);
    }
    public void ClickA3()
    {
        audioSource.PlayOneShot(seA3);
    }
    public void ClickA4()
    {
        audioSource.PlayOneShot(seA4, 0.5f);
    }

    public void ClickB()
    {
        imageB.sprite = imageC;
        audioSource.PlayOneShot(se2, 0.5f);
    }

    public void ClickC()
    {
        imageCObj.SetActive(false);
        audioSource.PlayOneShot(die, 0.5f);
    }

    public void ClickC2()
    {
        imageC2Obj.SetActive(false);
        audioSource.PlayOneShot(die2);
    }
    public void ClickC3()
    {
        imageC3Obj.SetActive(false);
        audioSource.PlayOneShot(die3);
    }
    public void ClickC4()
    {
        imageC4Obj.SetActive(false);
        audioSource.PlayOneShot(die4);
    }
    public void ClickD()
    {
        audioSource.PlayOneShot(se4);
        fly = true;
    }

    //score==score Scoretogo==go to result
    public int score;

    public static int ScoreToGo;
    public void Clicknext()
    {
        audioSource.PlayOneShot(system);
        Invoke(nameof(LoadScene), 0.3f);

        ScoreToGo = score;
    
    }
    void LoadScene()
    {
        SceneManager.LoadScene("RE");
    }

    //move to next scene(score)

}
