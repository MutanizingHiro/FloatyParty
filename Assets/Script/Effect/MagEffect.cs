using UnityEngine;

public class MagEffect : MonoBehaviour
{
    [Header("GameObject setting")]
    public float expirationTimer;
    public float rotationSpeed;

    private Vector2 dir;

    [Header("Force Values")]
    public float minForceX;
    public float maxForceX;
    public float minForceY;
    public float maxForceY;

    private Animator anim;
    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        anim.Play("magFadeOut");

        float forceX = Random.Range(minForceX, maxForceX);
        float forceY = Random.Range(minForceY, maxForceY);

        rb.linearVelocity = new Vector2(forceX, forceY);
        rb.angularVelocity = rotationSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        expirationTimer -= Time.deltaTime;

        if (expirationTimer <= 0)
        {
            Destroy(gameObject);
        }
    }
}
