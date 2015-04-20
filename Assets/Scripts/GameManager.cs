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

	// Use this for initialization
	void Start () 
    {
        points = 0;
        time = 0;
        isRunning = true;
        enemiesOnScreen = 1;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if(isRunning)
        {
            time += Time.deltaTime;
        }
	}

    public void AddPoints()
    {
        points += 1;
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
}
