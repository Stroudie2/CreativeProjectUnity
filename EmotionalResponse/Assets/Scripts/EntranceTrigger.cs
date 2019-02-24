using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntranceTrigger : MonoBehaviour {

    public Character_Controller player;
    public GameObject door;
    private AudioSource audioSource;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Character_Controller>();
        audioSource = door.GetComponent<AudioSource>();
        //door = GameObject.FindGameObjectWithTag("EntranceDoor").gameObject;
        if (door.name == "EntranceDoor")
        {
            door.SetActive(false);
        }
        else
        {
            door.SetActive(true);
        }
    }

void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            if (door.name == "KeyDoor")
            {
                Debug.Log("Key reuired door");
                if (player.HasKey)
                {
                    Debug.Log("Door removed");
                    door.SetActive(false);
                    //play door sound for disappearing
                    Destroy(this);
                    //destroy trigger

                }
            }

            //else
            //{
            //    //add audio cues here for door appearing
            //    if (door.activeSelf == false)
            //    {
            //        audioSource.time = 0.0f;
            //        audioSource.Play();
            //        door.SetActive(true);
            //    }
            //    else
            //    {
            //        door.SetActive(false);
            //        //play door sliding sound
            //    }
            //}
        }
    }
}
