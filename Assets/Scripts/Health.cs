using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    float minHealth = 1.5f;
    float maxHealth = 3.6f;
    float initialHealth;
    float currentHealth;
    float healthbarSize;
    public RectTransform healthbar;
    GameManager gameManager;
    bool isAlive;
    EnemyFollow enemyFollow;

	// Use this for initialization
	void Start () 
    {
        initialHealth = Random.Range(minHealth, maxHealth);
        currentHealth = initialHealth;
        healthbarSize = healthbar.sizeDelta.x;
        isAlive = true;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        enemyFollow = GetComponent<EnemyFollow>();
	}
	
	// Update is called once per frame
	void Update () {
        float healthpc = currentHealth / initialHealth;
        healthbar.sizeDelta = new Vector2(healthbarSize * healthpc, healthbar.sizeDelta.y);

        if (currentHealth <= 0 && isAlive)
            StartCoroutine("DeathRoutine");
	}

    public void TakeHit()
    {
        currentHealth -= Time.deltaTime;
    }

    IEnumerator DeathRoutine()
    {
        gameManager.AddPoints();
        isAlive = false;
        enemyFollow.isAlive = false;
        
        // adicionar codigo para animação
        yield return new WaitForSeconds(3); // setar o tempo correto de animação
        Destroy(gameObject);
        yield return null;
    }
}
