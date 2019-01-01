using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntranceTrigger : MonoBehaviour {

    private GameObject tree;
    void Start()
    {
        tree = GameObject.FindGameObjectWithTag("EntranceDoor").gameObject;
        tree.SetActive(false);
    }

void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //add audio cues here for tree growing
            tree.SetActive(true);
        }
    }
}
