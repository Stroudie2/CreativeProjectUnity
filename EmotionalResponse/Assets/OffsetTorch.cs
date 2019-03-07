using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetTorch : MonoBehaviour {

    private Vector3 offset;
    private GameObject followTarget;
    [SerializeField] private float speed = 3.0f;

	void Start () {
        followTarget = Camera.main.gameObject;
        offset = transform.position - followTarget.transform.position;  //allow torch to follow camera with a sway motion
	}
	
	void Update () {
        transform.position = followTarget.transform.position + offset;
        transform.rotation = Quaternion.Slerp(transform.rotation, followTarget.transform.rotation, speed * Time.deltaTime);     //smoothly rotate torch
	}
}
