using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour 
{
    public int health;
    GameManager gameManager;
    public Image heart1;
    public Image heart2;
    public Image heart3;
    public Sprite heartFull;
    public Sprite heartEmpty;
	
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
        if (health < 0)
            DeathRoutine();
    }

    void DeathRoutine()
    {
        gameManager.isRunning = false;
        Debug.Log("Morreu");
    }

    void OnGUI()
    {
        if(health == 3)
        {
            heart1.sprite = heartFull;
            heart2.sprite = heartFull;
            heart3.sprite = heartFull;
        }
        else if(health == 2)
        {
            heart1.sprite = heartEmpty;
            heart2.sprite = heartFull;
            heart3.sprite = heartFull;
        }
        else if(health == 1)
        {
            heart1.sprite = heartEmpty;
            heart2.sprite = heartEmpty;
            heart3.sprite = heartFull;
        }
        else if(health == 0)
        {
            heart1.sprite = heartEmpty;
            heart2.sprite = heartEmpty;
            heart3.sprite = heartEmpty;
        }
        //healthGUI.text = "Health: " + health.ToString();
    }


}
