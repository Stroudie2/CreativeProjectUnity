using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkLight : MonoBehaviour {

    public GameObject light;
    public bool lightFlicker;
    float timer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //light.gameObject.SetActive(true);
            lightFlicker = true;
            StartCoroutine(FlickeringLight());
        }
    }


	// Use this for initialization
	void Start () {
        light.gameObject.SetActive(false);
        lightFlicker = false;
	}
	
	IEnumerator FlickeringLight()
    {
        if (lightFlicker)
        {
            light.SetActive(true);
            timer = Random.Range(0.1f, 1f);
            yield return new WaitForSeconds(timer);
            light.SetActive(false);
            timer = Random.Range(.1f, 1f);
            yield return new WaitForSeconds(timer);
            StartCoroutine(FlickeringLight());
        }
    }
}
