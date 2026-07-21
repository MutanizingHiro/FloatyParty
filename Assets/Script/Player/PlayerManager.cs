using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    [Header("コンポーネント")]
    public E_HP healthBar;
    [Header("弾Prefab")]
    [SerializeField] GameObject weakBulletPrefab;
    [SerializeField] GameObject mediumBulletPrefab;
    [SerializeField] GameObject strongBulletPrefab;

    [Header("mag")]
    [SerializeField] GameObject emptyMag;
    [SerializeField] Transform magFirePosition;

    [Header("テスト用")]
    [SerializeField] Text text;

    [Header("パラメーター")]
    public float power;
    public Vector2 bulletVec;
    public bool canShoot = true;
    public float clickInterval;
    public float fillSpeed;

    public int maxHp;
    public int hp;
    public int score;

    public int damage;

    private Rigidbody2D rb;
    private Animator anim;

    [SerializeField] Transform firePoint;
    [SerializeField] GameObject gameManager;

    [SerializeField] Image targetGauge;

    private void Start()
    {
        score = 0;
        targetGauge.fillAmount = 0;

        anim = GetComponent<Animator>();
        healthBar = GetComponent<E_HP>();
        rb = GetComponent<Rigidbody2D>();


        if (healthBar != null)
        {
            healthBar.maxHP = this.maxHp;
        }
    }

    private void Update()
    {
        if (text != null)
        {
            text.text = "Power : " + power.ToString();
        }

        //弾の発射方向ベクトル
        if (InputManager.isMouseButtonOn)
        {
            //マウス座標取得
            Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            bulletVec = (worldMousePos - transform.position).normalized;
        }

        if (InputManager.isMouseButtonDown && canShoot)
        {
            StartCoroutine(ShootCoroutine());
        }
    }

    //プレイヤーの弾発射コルーチン
    IEnumerator ShootCoroutine()
    {
        //初期化
        power = 0.0f;
        canShoot = false;

        //チャージ
        while (InputManager.isMouseButtonOn)
        {
            anim.Play("Charging");
            targetGauge.fillAmount += fillSpeed * Time.deltaTime;

            if (power <= 1.0f)
            {
                power += fillSpeed * Time.deltaTime;
            }
            yield return null;
        }

        //チャージ力が最大なら強力な攻撃に切り替え
        GameObject shootPrefab = (power >= 1.0f) ? strongBulletPrefab : 
                                 (power >= 0.5f) ? mediumBulletPrefab : 
                                 weakBulletPrefab;
        

        //発射
        Shoot(shootPrefab);

        //発射間隔

        power = 0.0f;
        yield return new WaitForSeconds(clickInterval);
        canShoot = true;
        anim.Play("Idle");
    }

    //弾発射用
    void Shoot(GameObject prefab)
    {
        if (prefab != null)
        {
            targetGauge.fillAmount = 0;
            anim.Play("Attack");

            Instantiate(emptyMag, magFirePosition);

            //弾をプレイヤー位置から発射
            GameObject bullet = Instantiate(prefab,firePoint.position,transform.rotation);

            //BulletManager取得、威力とベクトルの設定
            BulletManager bm = bullet.GetComponent<BulletManager>();
            if (bm != null)
            {
                bm.power = power;
                bm.shootDir = bulletVec;
            }
        }
    }

    public void UpdateHealth()
    {
        hp--;
        healthBar.damageHP(1);

        if (hp <= 0)
        {
            Clicknext();
        }
    }


    public static int ScoreToGo;
    public void Clicknext()
    {
        Invoke(nameof(GameOverScene), 0.3f);

        ScoreToGo = score;
        RankingManager.SaveScore(ScoreToGo);
    }
    void GameOverScene()
    {
        GameManagerScript.instance.gameState = GameManagerScript.GameState.gameOver;
        SceneManager.LoadScene("GameOver");
    }
}