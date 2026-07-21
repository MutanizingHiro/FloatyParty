using UnityEngine;

public class CloudGenerator : MonoBehaviour
{
    public GameObject[] cloudObj;

    [SerializeField] private Transform spawnPositionTransform;
    [SerializeField] private Transform cloudParentTransform;

    [Header("Spawn Time")]
    public float minSpawnTime;
    public float maxSpawnTime;

    [Header("+- Y Axis Randomizer")]
    public float ascendAmount;
    public float descendAmount;


    private float randYAxis;

    private Vector3 spawnPoint;
    private float spawnTime;
    private float timer;

    private void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;

        if(timer >= spawnTime)
        {
            spawnTime = Random.Range(minSpawnTime, maxSpawnTime);

            randYAxis = Random.Range(spawnPositionTransform.position.y - descendAmount, spawnPositionTransform.position.y + ascendAmount);

            spawnPoint = new Vector3(spawnPositionTransform.position.x, randYAxis, spawnPositionTransform.position.z);

            int elementNum = Random.Range(0, cloudObj.Length);
            Instantiate(cloudObj[elementNum], spawnPoint, Quaternion.identity, cloudParentTransform);

            timer = 0.0f;
        }
    }
}
