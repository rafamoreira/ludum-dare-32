using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour 
{
    public int health;
    GameManager gameManager;
    public Text healthGUI;
	
    // Use this for initialization
	void Start () 
    {
        health = 3;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}
	
    public void TakeHitPlayer()
    {
        health -= 1;
    }

    void Update()
    {
        if (health <= 0)
            DeathRoutine();
    }

    void DeathRoutine()
    {
        gameManager.isRunning = false;
        Debug.Log("Morreu");
    }

    void OnGUI()
    {
        healthGUI.text = "Health: " + health.ToString();
    }


}
