using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    float minHealth = 1.5f;
    float maxHealth = 3.6f;
    float initialHealth;
    float currentHealth;

	// Use this for initialization
	void Start () 
    {
        initialHealth = Random.Range(minHealth, maxHealth);
        currentHealth = initialHealth;
	}
	
	// Update is called once per frame
	void Update () {
	    //Debug.Log("%: " +  (currentHealth / initialHealth) * 100 );
	}

    void OnGUI()
    {
        GUI.Box(new Rect(0, 0, 100, 100), ((currentHealth / initialHealth) * 100).ToString() + "%");
    }

    public void TakeHit()
    {
        currentHealth -= Time.deltaTime;
    }
}
