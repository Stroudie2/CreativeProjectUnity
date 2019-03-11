using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPlayer : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip flySound;
    Character_Controller player;
    Transform targetTransform;
    int moveSpeed = 20;
    int maxDist = 10;

	// Use this for initialization
	void Start () {
        targetTransform = GameObject.FindGameObjectWithTag("Player").transform.Find("TargetArea");
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Character_Controller>();
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if ((Vector3.Distance(transform.position, targetTransform.position) >= 0f) & (player.boxFly))
        {
            transform.LookAt(targetTransform);
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
            audioSource.PlayOneShot(flySound);
            //audio effect for flying toward player
            //if (Vector3.Distance(transform.position, targetTransform.position) <= 2.5f)
            //{
            //    //audioSource.clip = flySound;
            //    //audioSource.time = 0.0f;
            //    //audioSource.Play();
            //    audioSource.PlayOneShot(flySound);
            //}

            if (Vector3.Distance(transform.position, targetTransform.position) <= 0.2f)
            {
                transform.gameObject.SetActive(false);
                player.boxFly = false;
            }
        }
	}
}
