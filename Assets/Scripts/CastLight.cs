using UnityEngine;
using System.Collections;

public class CastLight : MonoBehaviour 
{

    public LayerMask mask;
    int rayLenghtDefault = 4;
    LineRenderer lightRenderer;
    LightDetect lightDetect;

	// Use this for initialization
	void Start () {
        lightDetect = GetComponentInParent<LightDetect>();
        lightRenderer = GetComponentInChildren<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        if (lightDetect.onLight)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.forward, rayLenghtDefault, mask);

            if (hit.collider != null)
            {
                lightRenderer.SetPosition(1, new Vector3(0, 0, hit.distance * 2));
                if(hit.collider.tag == "Enemy")
                {
                    hit.collider.SendMessage("TakeHit");
                }
            }
            else
                lightRenderer.SetPosition(1, new Vector3(0, 0, 8));
        }
	}
}
