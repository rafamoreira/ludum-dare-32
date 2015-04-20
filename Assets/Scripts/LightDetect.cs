using UnityEngine;
using System.Collections;

public class LightDetect : MonoBehaviour 
{

    public bool onLight = false;
    public GameObject laser;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "LightBeam")
            onLight = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "LightBeam")
            onLight = false;
    }

    void Update ()
    {
        if(onLight)
        {
            if(!laser.activeSelf)
                laser.SetActive(true);
            
        }
        else
        {
            if (laser.activeSelf)
                laser.SetActive(false);
        }

    }
}
