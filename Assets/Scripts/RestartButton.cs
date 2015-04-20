using UnityEngine;
using System.Collections;

public class RestartButton : MonoBehaviour {

	public void Restart()
    {
        //Debug.Log("button");
        Application.LoadLevel(1);
    }
}
