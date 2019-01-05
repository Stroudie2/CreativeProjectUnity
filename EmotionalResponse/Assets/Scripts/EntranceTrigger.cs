using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntranceTrigger : MonoBehaviour {

    public GameObject tree;
    private AudioSource audioSource;
    void Start()
    {
        audioSource = tree.GetComponent<AudioSource>();
        //tree = GameObject.FindGameObjectWithTag("EntranceDoor").gameObject;
        if (tree.name == "EntranceDoor")
        {
            tree.SetActive(false);
        }
        else
        {
            tree.SetActive(true);
        }
    }

void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //add audio cues here for tree growing
            if (tree.activeSelf == false)
            {
                audioSource.time = 0.0f;
                audioSource.Play();
                tree.SetActive(true);
            }
            else
            {
                tree.SetActive(false);
                //activate particle mist to location
            }
            Destroy(this);
            //destroy trigger
        }
    }
}
