using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyToLocation : MonoBehaviour {
    private AudioSource audioSource;
    public AudioClip flySound;
    Transform targetTransform;
    float moveSpeed = 25;
    public bool boxFly = false;
    public bool boxFly2 = false;
    bool finishedMove = false;
    bool finishedAudio = false;
    public GameObject[] boxes;
    Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        if (gameObject.tag == "FlyingBox")
        {
            int rand = Random.Range(0, 2);
            if (rand == 1)
            {
                targetTransform = GameObject.FindGameObjectWithTag("BoxTarget").transform;
            }
            else
            {
                targetTransform = GameObject.FindGameObjectWithTag("BoxTarget").transform.GetChild(0);
            }
            boxes = GameObject.FindGameObjectsWithTag("FlyingBox");
        }
        else
        {
            targetTransform = GameObject.FindGameObjectWithTag("BoxTarget2").transform;
            boxes = GameObject.FindGameObjectsWithTag("FlyingBox2");
        }
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (boxFly | boxFly2)
        {
            foreach(GameObject t in boxes)  //each box
            {
                if (!finishedMove)
                {
                    rb = t.GetComponent<Rigidbody>();
                    //moveSpeed = Random.Range(5.0f, 25f);
                    t.transform.LookAt(targetTransform);
                    rb.mass = t.transform.lossyScale.x;
                    rb.AddRelativeForce(Vector3.forward.normalized * moveSpeed, ForceMode.Force);
                }
                if ((Vector3.Distance(transform.position, targetTransform.position) >= 0.5f) & (!finishedAudio))
                {
                    audioSource.PlayOneShot(flySound);
                    finishedAudio = true;
                }
                if (Vector3.Distance(t.transform.position, targetTransform.position) <= 1.2f)   //when destination reached, destroy objects
                {
                    for (int i = 0; i < boxes.Length; i++)
                    {
                        rb.velocity = Vector3.zero;
                        finishedMove = true;
                    }
                    boxFly = false;
                }
            }
        }
    }
}
