using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectShake : MonoBehaviour {

    private bool shaking = false;
    public int shakeAmount;
    public Vector3 originalPos;

    private void Start()
    {
        shakeAmount = Random.Range(1, 8);
        originalPos = transform.position;
    }

    public void ShakeObject()
    {
        StartCoroutine("ShakeNow");
        Debug.Log(gameObject.name + " Shaking now");
    }

    IEnumerator ShakeNow()
    {

        if (!shaking)
        {
            shaking = true;
        }

        yield return new WaitForSeconds(2.3f);

        shaking = false;
        transform.position = originalPos;
    }
	
	void Update () {
        if (shaking)
        {
            Vector3 newPos = originalPos + Random.insideUnitSphere * (Time.deltaTime * shakeAmount);
            newPos.x = transform.position.x;
            transform.position = newPos;
        }
    }
}
