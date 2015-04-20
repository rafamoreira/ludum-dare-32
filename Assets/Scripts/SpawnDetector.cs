using UnityEngine;
using System.Collections;

public class SpawnDetector : MonoBehaviour {

    public bool isColliding;

    void Start()
    {
        isColliding = false;
    }
    
    void OnTriggerEnter2D()
    {
        isColliding = true;
    }

    void OnTriggerExit2D()
    {
        isColliding = false;
    }
}
