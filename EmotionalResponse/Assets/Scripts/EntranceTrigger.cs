using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntranceTrigger : MonoBehaviour {

    public Character_Controller player;
    public GameObject door;
    private AudioSource audioSource;
    private Animator animator;
    public AudioClip doorOpen;
    public AudioClip doorClose;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Character_Controller>();
        audioSource = door.GetComponent<AudioSource>();
        animator = door.GetComponent<Animator>();
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
        if (other.gameObject.tag == "PlayerHead")
        {
            if (door.name == "KeyDoor")
            {
                Debug.Log("Key required door");
                if (player.HasKey)
                {
                    animator.SetBool("close", false);
                    animator.SetBool("open", true);
                    audioSource.clip = doorOpen;
                    audioSource.time = 0.0f;
                    audioSource.Play();
                    //play door sound for sliding
                }
            }
            else
            {
                animator.SetBool("close", false);
                animator.SetBool("open", true);
                audioSource.clip = doorOpen;
                audioSource.time = 0.0f;
                audioSource.Play();
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

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "PlayerHead")
        {
            if (door.name == "KeyDoor")
            {
                Debug.Log("Player exit");
                if (player.HasKey)
                {
                    animator.SetBool("open", false);
                    animator.SetBool("close", true);
                    audioSource.clip = doorClose;
                    audioSource.time = 0.0f;
                    audioSource.Play();
                    //play door sound for sliding
                }
            }
            else
            {
                animator.SetBool("open", false);
                animator.SetBool("close", true);
                audioSource.clip = doorClose;
                audioSource.time = 0.0f;
                audioSource.Play();
            }
        }
    }
}
