using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyToLocation : MonoBehaviour {
    private AudioSource audioSource;
    public AudioClip flySound;
    Character_Controller player;
    Transform targetTransform;
    int moveSpeed = 5;
    int maxDist = 10;
    public bool boxFly = false;
    public GameObject[] boxes;

    // Use this for initialization
    void Start()
    {
        targetTransform = GameObject.FindGameObjectWithTag("BoxTarget").transform;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Character_Controller>();
        audioSource = GetComponent<AudioSource>();
        boxes = GameObject.FindGameObjectsWithTag("FlyingBox");
    }

    // Update is called once per frame
    void Update()
    {
        if (boxFly)
        {
            foreach(GameObject t in boxes)  //each box
            {
                t.transform.LookAt(targetTransform);
                t.transform.position += transform.forward * moveSpeed * Time.deltaTime;     //fly to position
                //play audio
                if (Vector3.Distance(t.transform.position, targetTransform.position) <= 0.2f)   //when destination reached, destroy objects
                {
                    t.transform.gameObject.SetActive(false);
                    Destroy(t.transform.gameObject);
                    boxFly = false;
                }
            }
        }
    }
}
