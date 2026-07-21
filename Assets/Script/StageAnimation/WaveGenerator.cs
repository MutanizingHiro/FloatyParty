using UnityEngine;

public class WaveGenerator : MonoBehaviour
{
    [SerializeField] private GameObject seaWavePrefab;
    [SerializeField] private Transform spawnPosition;

    public float spawnTimer;
    private float timer;

    private void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;

        if ( timer >= spawnTimer)
        {
            Instantiate(seaWavePrefab, spawnPosition);
            timer = 0.0f;
        }
    }
}
