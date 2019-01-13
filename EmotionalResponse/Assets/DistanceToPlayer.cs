using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceToPlayer : MonoBehaviour {

    [Header("Distance Values")]
    public float playerDistance;
    public float distanceTrigger;
    public GameObject player;

    [Header("Audio")]
    public AudioClip[] treeSounds;
    public AudioClip clipToPlay;
    private GameObject audioManager;
    private AudioSource audioSource;

    private int randomNumber;

    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        playerDistance = 0.0f;
        randomNumber = 0;
        audioManager = GameObject.Find("Audio Source");
        audioSource = audioManager.GetComponent<AudioScript>().audioSource;
    }
	
	void Update () {
        playerDistance = Vector3.Distance(transform.position, player.transform.position);
        if (playerDistance < distanceTrigger)
        {
            PlayAudioClip();
        }
	}

    void PlayAudioClip()
    {
        //chance based values for each clip to be played
        randomNumber = Random.Range(0, 90000);

        if (randomNumber < 10)
        {
            switch (randomNumber)
            {
                case 0:
                    clipToPlay = treeSounds[0];
                    break;
                case 1:
                    clipToPlay = treeSounds[1];
                    break;
                case 2:
                    clipToPlay = treeSounds[2];
                    break;
                case 3:
                    clipToPlay = treeSounds[3];
                    break;
                case 4:
                    clipToPlay = treeSounds[4];
                    break;
                case 5:
                    clipToPlay = treeSounds[5];
                    break;
                case 6:
                    clipToPlay = treeSounds[6];
                    break;
                case 7:
                    clipToPlay = treeSounds[7];
                    break;
                case 8:
                    clipToPlay = treeSounds[8];
                    break;
                case 9:
                    clipToPlay = treeSounds[9];
                    break;
                default:
                    break;
            }
        }
        audioManager.GetComponent<AudioScript>().setAudio(clipToPlay);
        //audioSource.time = 0.0f;
        audioSource.Play();
        //audioSource.PlayOneShot(clipToPlay);
    }
}
