using System.Collections;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    [Header("敵に当たった後に出現させるパーティクルPrefab")]
    public GameObject particlePrefab;

    [Header("軌道予測用の弾か、実際に撃つ弾か")]
    public bool isBullet;
    [Header("プレイヤーから受け取る変数")]
    public float power;
    public Vector2 shootDir;
    public int damage;
    [Header("パラメーター")]
    [SerializeField] float minSpeed;
    [SerializeField] float maxSpeed;
    [SerializeField] float speed;

    [SerializeField] float gravityScale = 1f;


    [Header("コンポーネント")]
    [SerializeField] Rigidbody2D rb;
    public GameObject splashEffectObj;
    public bool destroyUponImpact;

    private void Start()
    {
            rb = GetComponent<Rigidbody2D>();

            // power に応じて重力を切り替え
            rb.gravityScale = (power >= 1f) ? gravityScale : 0f;

            // power で速度を補間
            speed = Mathf.Lerp(minSpeed, maxSpeed, power);

            // Rigidbody2D に速度を設定（物理挙動）
            rb.linearVelocity = shootDir.normalized * speed;

        // 進行方向に回転させる
        float angle = Mathf.Atan2(rb.linearVelocity.y, rb.linearVelocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        //６秒後にはオブジェクトを削除（絶対に画面外に行ってる時間）
        Destroy(gameObject, 6f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<IPlayerDamageable>()  != null)
        {
            //IPlayerDamageableがあるオブジェクトであればダメージ処理を実行
            collision.GetComponent<IPlayerDamageable>().Hit(damage);

            //パーティクルとして使うオブジェクトがあれば出現させる
            if (particlePrefab != null)
            {
                GameObject particle = Instantiate(particlePrefab, transform.position, transform.rotation);
            }

            if (destroyUponImpact)
            {
                Destroy(gameObject);
            }
        }
    }
}
