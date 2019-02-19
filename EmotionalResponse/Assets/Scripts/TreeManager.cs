using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeManager : MonoBehaviour {


	void Start () {
		foreach(Transform tree in transform)
        {
            //tree.eulerAngles = new Vector3(0f, Random.value * 359f, 0f);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
