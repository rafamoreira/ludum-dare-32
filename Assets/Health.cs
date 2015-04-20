using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    float minHealth = 1.5f;
    float maxHealth = 3.6f;
    float initialHealth;
    float currentHealth;
    float healthbarSize;
    public RectTransform healthbar;

	// Use this for initialization
	void Start () 
    {
        initialHealth = Random.Range(minHealth, maxHealth);
        currentHealth = initialHealth;
        healthbarSize = healthbar.sizeDelta.x;
	}
	
	// Update is called once per frame
	void Update () {
        float healthpc = currentHealth / initialHealth;
        healthbar.sizeDelta = new Vector2(healthbarSize * healthpc, healthbar.sizeDelta.y);
	}

    public void TakeHit()
    {
        currentHealth -= Time.deltaTime;
    }
}
