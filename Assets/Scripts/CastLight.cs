using UnityEngine;
using System.Collections;

public class CastLight : MonoBehaviour 
{

    public LayerMask mask;


    LightDetect lightDetect;

	// Use this for initialization
	void Start () {
        lightDetect = GetComponentInParent<LightDetect>();
	}
	
	// Update is called once per frame
	void Update () {
        if (lightDetect.onLight)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.forward, Mathf.Infinity, mask);

            if (hit.collider != null)
            {
                Debug.Log(hit.collider.name);
            }
        }
	}
}
