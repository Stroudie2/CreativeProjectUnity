﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPlayer : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip flySound;
    public AudioClip hitSound;
    Character_Controller player;
    Transform targetTransform;
    Rigidbody rb;
    float moveSpeed = 50f;
    bool finishedMove = false;
    bool finishedAudio = false;

	// Use this for initialization
	void Start () {
        targetTransform = GameObject.FindGameObjectWithTag("Player").transform.Find("TargetArea");
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Character_Controller>();
        audioSource = GetComponent<AudioSource>();
        rb = gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if ((Vector3.Distance(transform.position, targetTransform.position) >= 0f) & (player.boxFly) & (!finishedMove))
        {
            transform.LookAt(targetTransform);
            rb.AddRelativeForce(Vector3.forward * moveSpeed, ForceMode.Force);

            if ((Vector3.Distance(transform.position, targetTransform.position) <= 6.0f) & (!finishedAudio))
            {
                audioSource.PlayOneShot(flySound);
                finishedAudio = true;
                gameObject.AddComponent<BoxHitFloor>().FirstHitFloor = true;
                GetComponent<BoxHitFloor>().floorHitSound = hitSound;   //sets the sound to be played when hitting floor
            }

            if (Vector3.Distance(transform.position, targetTransform.position) <= 3.0f)
            {
                rb.velocity = Vector3.zero;
                finishedMove = true;
            }
        }
	}
}
