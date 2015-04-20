using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    float minHealth = 1f;
    float maxHealth = 2.5f;
    float initialHealth;
    float currentHealth;
    float healthbarSize;
    public RectTransform healthbar;
    GameManager gameManager;
    bool isAlive;
    EnemyFollow enemyFollow;
	Animator anim;

	// Use this for initialization
	void Start () 
    {
        initialHealth = Random.Range(minHealth, maxHealth);
        currentHealth = initialHealth;
        healthbarSize = healthbar.sizeDelta.x;
        isAlive = true;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        enemyFollow = GetComponent<EnemyFollow>();
        
        anim = GetComponentInChildren<Animator>();
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
        
        anim.SetBool("DeadAnim", true);
        yield return new WaitForSeconds(1); // setar o tempo correto de animação
        Destroy(gameObject);
        yield return null;
    }
}
