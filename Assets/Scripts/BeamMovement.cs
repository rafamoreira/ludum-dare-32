using UnityEngine;
using System.Collections;

public class BeamMovement : MonoBehaviour {
    
    Quaternion to;
    internal bool isRotating = false;
	
    void Start () 
    {   
        isRotating = false;
        PrepareRotation();
	}
	
	void Update () 
    {
        if(isRotating)
            transform.rotation = Quaternion.Lerp(transform.rotation, to, Time.deltaTime * 0.005f);
	}

    public void PrepareRotation()
    {
        to = transform.rotation;
        to.z = to.z + Random.Range(45, 190);
    }
}
