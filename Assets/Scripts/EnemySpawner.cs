using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    public Transform[] spawnPoints;
    public Transform prefab;
    GameManager gameManager;
    float timer;
    float timeMax = 3f;
    float timeMin = 1f;
    public int maxEnemies;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        timer = Random.Range(timeMin, timeMax);
        maxEnemies = 1;
    }

    void Update()
    {

        if (maxEnemies < 5)
        {
            if (gameManager.enemiesOnScreen < maxEnemies)
                timer -= Time.deltaTime;
        }
        else
            timer -= Time.deltaTime;
        

        if (timer <= 0 && gameManager.enemiesOnScreen < maxEnemies)
        {
            Spawn();
            timer = Random.Range(timeMin, timeMax);
        }
        
    }

	void Spawn()
    {
        int i = Random.Range(0, spawnPoints.Length);

        if (spawnPoints[i].GetComponent<SpawnDetector>().isColliding)
            Spawn();
        else
        {
            Instantiate(prefab, spawnPoints[i].position, spawnPoints[i].rotation);
            gameManager.AddEnemy();
        }
            
    }

    public void CheckMaxEnemies(int points)
    {
        if (points == 1)
            maxEnemies = 2;
        else if (points == 3)
            maxEnemies = 3;
        else if (points == 6)
            maxEnemies = 4;
        else if (points == 10)
            maxEnemies = 5;
        else if (points == 15)
            maxEnemies = 6;
        else if (points == 25)
            maxEnemies = 7;
        else if (points == 30)
            maxEnemies = 8;
    }
}
