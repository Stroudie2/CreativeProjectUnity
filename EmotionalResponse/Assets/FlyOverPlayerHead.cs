using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyOverPlayerHead : MonoBehaviour {

    public List<GameObject> vents;
    public GameObject box;
    public AudioClip flySound;
    public AudioClip rattleSound;
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
                StartCoroutine("WaitForShake");     //wait some time before triggering the vent shake
            }
        }
    }

    IEnumerator WaitForShake()
    {
        yield return new WaitForSeconds(3f);
        StartCoroutine("ShakeVents");
    }

    IEnumerator ShakeVents()
    {
        for (int i = 0; i < vents.Count; i++)
        {
            vents[i].GetComponent<ObjectShake>().ShakeObject();
            vents[i].GetComponentInParent<AudioSource>().PlayOneShot(rattleSound);   //play rattle sound as vents shake
            yield return new WaitForSeconds(1f);
        }
        transform.gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
