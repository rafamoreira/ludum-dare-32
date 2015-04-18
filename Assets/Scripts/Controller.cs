using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour 
{
    Rigidbody2D myRigidbody;
    public float playerSpeed = 3;

    void Start ()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

	void Update () 
    {
        Rotate();
	}

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
            Vector2 vel = new Vector2(playerSpeed * Input.GetAxis("Horizontal"), playerSpeed * Input.GetAxis("Vertical"));
            myRigidbody.velocity = vel;
    }

    void Rotate()
    {
        Vector2 mousePos = Input.mousePosition;
        Vector3 screenPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, transform.position.z - Camera.main.transform.position.z));

        Vector3 euler = transform.eulerAngles;
        euler.z = Mathf.Atan2((screenPos.y - transform.position.y), (screenPos.x - transform.position.x)) * Mathf.Rad2Deg;

        transform.eulerAngles = euler;
    }
}
