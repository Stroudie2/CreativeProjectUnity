using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PlayerHead")
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Character_Controller>().HasKey = true;
            Destroy(this.gameObject);
            //play pickup sound here
        }
    }
}
