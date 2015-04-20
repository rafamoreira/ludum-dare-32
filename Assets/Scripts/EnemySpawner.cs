using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    public Transform[] spawnPoints;
    public Transform prefab;
    GameManager gameManager;
    float timer;
    float timeMax = 3f;
    float timeMin = 1f;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        timer = Random.Range(timeMin, timeMax);
    }

    void Update()
    {
        timer -= Time.deltaTime;
        
        if(timer <= 0)
        {
            if(gameManager.enemiesOnScreen <= 5)
            {
                Spawn();
            }
            timer = Random.Range(timeMin, timeMax);
        }

        if (Input.GetKeyDown(KeyCode.Space))
            Spawn();
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
}
