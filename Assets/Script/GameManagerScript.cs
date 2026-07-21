using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public float screenTransitionTimer;

   public static GameManagerScript instance { get; private set; }

   public enum GameState
    {
        titleScreen,
        mainScreen,
        gameOver,
    }

    private Animator anim;

    public GameState gameState;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        gameState = GameState.titleScreen;
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //quit
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        //titleScreen to mainGame
         if (gameState == GameState.titleScreen)
        {
            if (Input.GetMouseButtonDown(0))
            {
                StartCoroutine(TitleScreenToMainGame());
            }
        }

         if(Input.GetKeyDown(KeyCode.C))
        {
            StartCoroutine(TitleScreenToMainGame());
        }

         if(Input.GetKeyDown(KeyCode.V))
        {
            SceneManager.LoadScene("GameOver");
        }

         if(Input.GetKeyDown(KeyCode.B))
        {
            StartCoroutine(GameOverScreenToTitleScreen());
        }
    }

    IEnumerator TitleScreenToMainGame()
    {
        anim.Play("FadeIn");

        yield return new WaitForSeconds(screenTransitionTimer);

        gameState = GameState.mainScreen;
        SceneManager.LoadScene("MainGame");

        yield return new WaitForSeconds(screenTransitionTimer);

        anim.Play("FadeOut");
    }
    public IEnumerator GameOverScreenToMainGame()
    {
        anim.Play("FadeIn");

        yield return new WaitForSeconds(screenTransitionTimer);

        gameState = GameState.mainScreen;
        SceneManager.LoadScene("MainGame");

        yield return new WaitForSeconds(screenTransitionTimer);

        anim.Play("FadeOut");
    }
    public IEnumerator GameOverScreenToTitleScreen()
    {
        anim.Play("FadeIn");

        yield return new WaitForSeconds(screenTransitionTimer);

        gameState = GameState.titleScreen;
        SceneManager.LoadScene("TitleScreen");

        yield return new WaitForSeconds(screenTransitionTimer);

        anim.Play("FadeOut");
    }
}
