using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour 
{

    float playerSpeed = 3;

	void Update () 
    {
        Move();
        Rotate();
	}

    void Move()
    {
        if(Input.GetAxis("Horizontal") != 0)
        {
            transform.Translate(playerSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0, 0, Space.World);
        }

        if(Input.GetAxis("Vertical") != 0)
        {
            transform.Translate(0, playerSpeed * Input.GetAxis("Vertical") * Time.deltaTime, 0, Space.World);
        }

    //    if(Input.GetKey("up"))
    //    {
    //        transform.Translate(0, playerSpeed * Time.deltaTime, 0, Space.World);
    //    }

    //    if(Input.GetKey("down"))
    //    {
    //        transform.Translate(0, -playerSpeed * Time.deltaTime, 0, Space.World);
    //    }

    //    if(Input.GetKey("left"))
    //    {
    //        transform.Translate(-playerSpeed * Time.deltaTime, 0, 0, Space.World);
    //    }

    //    if(Input.GetKey("right"))
    //    {
    //        transform.Translate(playerSpeed * Time.deltaTime, 0, 0, Space.World);
    //    }
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
