using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [System.Serializable]
    public class EnemySpawnData
    {
        public GameObject enemyPrefab;
        public int chanceSpawn;
        public bool randomSpawn;
    }
    public List<EnemySpawnData> enemyList;

    public float posX;
    public float posY;
    
    public float rampDifficultyTimer;
    public float rampDifficultyIncrease;

    private int totalChanceValue;
    public float spawnTimerLimiter;
    public float spawnTimer;

    private float sTimer;
    private float dTimer;

    private void Start()
    {
        totalChanceValue = 0;

        for (int i = 0; i < enemyList.Count; i++)
        {
            totalChanceValue += enemyList[i].chanceSpawn;
        }
    }
    private void Update()
    {
        this.sTimer += Time.deltaTime;
        
        if (spawnTimer >= spawnTimerLimiter)
        {
            this.dTimer += Time.deltaTime;
        }

        //spawn
        if (sTimer >= spawnTimer)
        {
            sTimer = 0;

            EnemySpawnData chosen = ChosenEnemy();

            float spawnY = chosen.randomSpawn ? Random.Range(-4, 2) : posY;

            Instantiate(chosen.enemyPrefab, new Vector2(posX, spawnY), Quaternion.identity);
        }

        //ramp difficulty
        if (dTimer >= rampDifficultyTimer)
        {
            dTimer = 0;

            spawnTimer -= rampDifficultyIncrease;
        }
    }

    private EnemySpawnData ChosenEnemy()
    {
        int roll = Random.Range(0, totalChanceValue);
        int cumulative = 0;

        
        for (int i = 0; i < enemyList.Count; i++)
        {
            cumulative += enemyList[i].chanceSpawn;

            if (roll <= cumulative)
            {
                return enemyList[i];
            }
        }

        return null;
    }
}
