﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public List<AudioClip> pipeAudioClips;
    public Character_Controller controller;
    private float lastPlayedTime = 0f;
    float playWaitTime = 0f;

    public GameObject lastPlayedPipe;
    public AudioClip lastPlayedClip;

    public void PlayPipeSound()
    {
        if (controller.nearbyPipes.Count > 0)   //checks trees around player
        {
            GameObject selectedPipe = controller.nearbyPipes[Random.Range(0, controller.nearbyPipes.Count)];    //pick random pipe from around player
            if ((selectedPipe == lastPlayedPipe) & (controller.nearbyPipes.Count > 1))  //don't play sound at same location twice
            {
                while (selectedPipe == lastPlayedPipe)
                {
                    selectedPipe = controller.nearbyPipes[Random.Range(0, controller.nearbyPipes.Count)];   //forces to pick another pipe
                }

            }
            else if (selectedPipe != lastPlayedPipe)
            {
                lastPlayedPipe = selectedPipe;
                while (selectedPipe.GetComponent<AudioSource>().clip == lastPlayedClip)     //regenerate whilst it's the same
                {
                    selectedPipe.GetComponent<AudioSource>().clip = pipeAudioClips[Random.Range(0, pipeAudioClips.Count)];  //choose random pipe sound
                }
                lastPlayedClip = selectedPipe.GetComponent<AudioSource>().clip;
                selectedPipe.GetComponent<AudioSource>().Play();
            }
        }


        playWaitTime = Random.Range(3f, 15f);   //wait a random time period before next sound can be played
        lastPlayedTime = Time.time;
    }

    void Update()
    {
        if (Time.time >= lastPlayedTime + playWaitTime)
        {
            PlayPipeSound();            
        }
    }
}
