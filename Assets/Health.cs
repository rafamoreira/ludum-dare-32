using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    float minHealth = 1.5f;
    float maxHealth = 3.6f;
    float initialHealth;
    float currentHealth;
    float healthBarSize;
    public RectTransform healtbar;

	// Use this for initialization
	void Start () 
    {
        initialHealth = Random.Range(minHealth, maxHealth);
        currentHealth = initialHealth;
        healthBarSize = healtbar.sizeDelta.x;
	}
	
	// Update is called once per frame
	void Update () {
        float healthpc = currentHealth / initialHealth;
        healtbar.sizeDelta = new Vector2(healthBarSize * healthpc, healtbar.sizeDelta.y);
	}

    public void TakeHit()
    {
        currentHealth -= Time.deltaTime;
    }
}
