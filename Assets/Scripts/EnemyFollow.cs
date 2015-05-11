using UnityEngine;
using System.Collections;

public class EnemyFollow : MonoBehaviour {

    GameObject player;
    public float speed = 1;
    public float rotSpeed;
    public bool isAlive;
    GameManager myGameManager;

	// Use this for initialization
	void Start () 
    {
        myGameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        player = GameObject.Find("Player");
        if (myGameManager.points <= 15)
          speed = Random.Range(0.5f, 1.5f);
        else
            speed = Random.Range(1f, 2f);
        rotSpeed = Random.Range(1, 11);
        isAlive = true;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if(isAlive)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

            Vector3 vectorToTarget = player.transform.position - transform.position;
            float angle = (Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg) - 90;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * rotSpeed);
        }
        
	}

    void OnCollisionEnter2D(Collision2D hit)
    {
        if(isAlive)
        {
            if (hit.transform.tag == "Player")
                hit.transform.SendMessage("TakeHitPlayer");
        }
        
    }
}
