using UnityEngine;
using System.Collections;

public class BeamController : MonoBehaviour {

    GameObject beam;
    BeamMovement beamMovement;
    LightDetect lightDetect;
    int beamRoutine;
    float timer;
    bool routineStarted;

	void Start () 
    {
        lightDetect = GameObject.Find("Player").GetComponent<LightDetect>();
        beam = GameObject.Find("Beam");
        beamMovement = beam.GetComponent<BeamMovement>();
        beamRoutine = 0;
        timer = 0;
        routineStarted = false;
	}
	
    void Update () 
    {
        timer += Time.deltaTime;

        if(timer >= 3 && !routineStarted)
        {
            StartBeamRoutine();
            routineStarted = true;
        }
	}

    void StartBeamRoutine()
    {
        if (beamRoutine == 0)
            StartCoroutine("Beam0");
        else
            StartCoroutine("Beam1");
    }

    // 0 is the rotating beam
    IEnumerator Beam0 ()
    {
        beamMovement.PrepareRotation();
        beamMovement.isRotating = true;
        yield return new WaitForSeconds(3);
        beamMovement.isRotating = false;
        beamRoutine = 1;
        timer = 0;
        routineStarted = false;
        yield return null;
    }

    // 1 is the moving beam
    IEnumerator Beam1 ()
    {
        beam.SetActive(false);
        lightDetect.onLight = false;
        yield return new WaitForSeconds(0.1f);
        beam.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        beam.SetActive(false);
        lightDetect.onLight = false;
        yield return new WaitForSeconds(0.2f);
        beam.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        beam.SetActive(false);
        lightDetect.onLight = false;
        yield return new WaitForSeconds(0.3f);
        beam.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        beam.SetActive(false);
        lightDetect.onLight = false;
        yield return new WaitForSeconds(0.4f);
        beam.transform.Rotate(0, 0, beam.transform.rotation.z + Random.Range(45, 190));
        beam.SetActive(true);
        beamRoutine = 0;
        timer = 0;
        routineStarted = false;
        yield return null;
        
    }
}
