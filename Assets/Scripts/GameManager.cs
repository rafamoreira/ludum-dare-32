using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public int points;
    public float time;
    public bool isRunning;
    public Text scoreGUI;
    public Text timerGUI;
    public int enemiesOnScreen;
    public bool endScreen;
    public GameObject endObject;
    public bool started;
    public Text countdown;
    EnemySpawner myEnemySpawner;

	// Use this for initialization
	void Start () 
    {
        points = 0;
        time = 0;
        isRunning = false;
        endScreen = false;
        started = false;
        Time.timeScale = 0;
        enemiesOnScreen = 1;
        StartCoroutine("StartGame");
        myEnemySpawner = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if(isRunning)
        {
            time += Time.deltaTime;
        }
        if (started && !isRunning && !endScreen)
        {
            Time.timeScale = 0;
            endScreen = true;
            endObject.SetActive(true);
        }
	}

    public void AddPoints()
    {
        points += 1;
        enemiesOnScreen -= 1;

        myEnemySpawner.CheckMaxEnemies(points);
    }

    void OnGUI()
    {
        scoreGUI.text = "Kills: " + points.ToString();

        int minutes = Mathf.FloorToInt(time / 60F);
        int seconds = Mathf.FloorToInt(time - minutes * 60);

        timerGUI.text = string.Format("{0:0}:{1:00}", minutes, seconds);
    }

    public void AddEnemy()
    {
        enemiesOnScreen += 1;
    }

    public void End()
    {
        isRunning = false;
    }

    IEnumerator StartGame()
    {
        float time = 1;
        float start = Time.realtimeSinceStartup;

        countdown.text = "3";
        while(Time.realtimeSinceStartup < start + time)
            yield return null;

        start = Time.realtimeSinceStartup;
        countdown.text = "2";
        while (Time.realtimeSinceStartup < start + time)
            yield return null;

        start = Time.realtimeSinceStartup;
        countdown.text = "1";
        while (Time.realtimeSinceStartup < start + time)
            yield return null;

        start = Time.realtimeSinceStartup;
        time = 0.5f;
        countdown.text = "Go!";
        while (Time.realtimeSinceStartup < start + time)
            yield return null;

        countdown.text = "";
        Time.timeScale = 1;
        isRunning = true;
        started = true;
        
    }
}
