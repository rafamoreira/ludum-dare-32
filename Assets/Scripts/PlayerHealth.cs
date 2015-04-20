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
    SpriteRenderer spriteRenderer;
    Controller playerController;
	
    // Use this for initialization
	void Start () 
    {
        health = 3;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        playerController = GetComponent<Controller>();
	}
	
    public void TakeHitPlayer()
    {
        health -= 1;
        if(health >= 0)
        {
            StartCoroutine("PlayerHit");
        }
    }

    void Update()
    {
        if (health < 0)
            DeathRoutine();

        //Debug.Log(playerLayer);
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

    IEnumerator PlayerHit()
    {
        Physics2D.IgnoreLayerCollision(10, 8, true);
        playerController.playerSpeed = 4;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.enabled = false;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.enabled = true;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.enabled = false;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.enabled = true;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.enabled = false;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.enabled = true;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.enabled = false;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.enabled = true;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.enabled = false;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.enabled = true;
        playerController.playerSpeed = 2;
        Physics2D.IgnoreLayerCollision(10, 8, false);
        yield return null;
    }


}
