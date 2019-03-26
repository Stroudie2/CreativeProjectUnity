using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour {

    Character_Controller playerController;
    KeyPickupUI pickupUI;

    private void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<Character_Controller>();
        pickupUI = GameObject.FindGameObjectWithTag("Player").GetComponent<KeyPickupUI>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PlayerHead")
        {
            playerController.HasKey = true;
            GameObject.Find("LightTrigger").GetComponent<BlinkLight>().lightFlicker = false;
            GameObject.Find("LightTrigger").SetActive(false);
            playerController.audioSource.time = 0.0f;
            playerController.audioSource.PlayOneShot(playerController.clips[9]);
            //pickupUI.displayTime = 2.0f;    //display time for ui
            Destroy(this.gameObject);
        }
    }
}
