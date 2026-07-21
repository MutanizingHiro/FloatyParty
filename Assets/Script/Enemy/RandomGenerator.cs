using UnityEngine;

public class RandomGenerator : MonoBehaviour
{
    public GameObject[] enemyPrefab = new GameObject[4];
    public float span;
    float delta = 0;
    int dice;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;
            dice = Random.Range(0, 4);//4‘Ì‚Ì‚¤‚¿ˆê‘Ì

            float posX = 11.0f;
            float posY = -1.5f;

            Instantiate(enemyPrefab[dice], new Vector2(posX, posY), Quaternion.identity);
            
        }
    }
}
