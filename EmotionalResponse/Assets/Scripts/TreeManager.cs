using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeManager : MonoBehaviour {


	void Start () {
		foreach(Transform tree in transform)
        {
            tree.GetChild(0).eulerAngles = new Vector3((Random.value * 359f), 90f, 90f);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
