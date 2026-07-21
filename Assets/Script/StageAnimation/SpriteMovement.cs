using UnityEngine;

public class SpriteMovement : MonoBehaviour
{
    [Header("Direction Axis")]
    public float xAxis;
    public float yAxis;

    [Header("Out of Bounds")]
    public float xAxisLimitLeft;
    public float xAxisLimitRight;
    public float yAxisLimitUp;
    public float yAxisLimitDown;

    [Header("Speed Randomizer")]
    public float minSpeed;
    public float maxSpeed;

    private float speed;

    private void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
    }

    private void FixedUpdate()
    {
        transform.position = transform.position + new Vector3(xAxis * Time.fixedDeltaTime, yAxis * Time.fixedDeltaTime, 0) * speed;

        if(transform.position.x <= xAxisLimitLeft || transform.position.x >= xAxisLimitRight)
        {
            Destroy(gameObject);
        }

        if(transform.position.y <= yAxisLimitDown || transform.position.y >= yAxisLimitUp)
        {
            Destroy(gameObject);
        }
    }
}
