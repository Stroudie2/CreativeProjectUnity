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
    public GameObject[] boxes;

    // Use this for initialization
    void Start()
    {
        if (gameObject.tag == "FlyingBox")
        {
            targetTransform = GameObject.FindGameObjectWithTag("BoxTarget").transform;
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
                moveSpeed = Random.Range(5.0f, 25f);
                t.transform.LookAt(targetTransform);
                t.transform.position += transform.forward * moveSpeed * Time.deltaTime;     //fly to position
                //audioSource.PlayOneShot(flySound);
                //play audio
                if (Vector3.Distance(t.transform.position, targetTransform.position) <= 0.2f)   //when destination reached, destroy objects
                {
                    for (int i = 0; i < boxes.Length; i++)
                    {
                        boxes[i].SetActive(false);
                        Destroy(boxes[i]);
                        Destroy(targetTransform.gameObject);
                    }
                    //t.transform.gameObject.SetActive(false);
                    //Destroy(t.transform.gameObject);
                    boxFly = false;
                }
            }
        }
    }
}
