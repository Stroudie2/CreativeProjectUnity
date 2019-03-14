using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyOverPlayerHead : MonoBehaviour {

    public GameObject box;
    public AudioClip flySound;
    GameObject player;
    Transform playerHeadTarget;
    bool launchBox = false;
    bool finishedAudio = false;
    BoxHitFloor boxHit;

    Rigidbody boxRb;
    float moveSpeed = 10f;

	// Use this for initialization
	void Start () {
        box.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
        if (gameObject.name == "BoxFlyPastPlayerTrigger")
        {
            playerHeadTarget = player.transform.Find("TargetArea");
        }
        else
        {
            playerHeadTarget = player.transform.Find("TargetBehind");
        }
        boxRb = box.GetComponent<Rigidbody>();
        boxHit = box.GetComponent<BoxHitFloor>();
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerHead")
        {
            box.SetActive(true);
            launchBox = true;
        }
    }

    // Update is called once per frame
    void Update () {
		if (launchBox)
        {
            box.transform.LookAt(playerHeadTarget);
            boxRb.AddRelativeForce(Vector3.forward * moveSpeed, ForceMode.Impulse);
            if (Vector3.Distance(box.transform.position, playerHeadTarget.position) <= 1.2)
            {
                box.GetComponent<AudioSource>().PlayOneShot(flySound);
                finishedAudio = true;
                boxHit.FirstHitFloor = true;    //only play sound of hitting ground when dropping from air
                boxRb.velocity = Vector3.zero;
                launchBox = false;
                transform.gameObject.SetActive(false);
                Destroy(gameObject);
            }
        }
    }
}
