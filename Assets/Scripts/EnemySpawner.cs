using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    public Transform[] spawnPoints;
    public Transform prefab;
    GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
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
