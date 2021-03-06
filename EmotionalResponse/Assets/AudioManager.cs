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
        if (controller.nearbyPipes.Count > 0)   //checks pipes around player
        {
            GameObject selectedPipe = controller.nearbyPipes[Random.Range(0, controller.nearbyPipes.Count)];    //pick random pipe from around player
            if ((selectedPipe == lastPlayedPipe) & (controller.nearbyPipes.Count > 1))  //don't play sound at same location twice
            {
                int count = 0;
                while ((selectedPipe == lastPlayedPipe) & (count < 10))
                {
                    selectedPipe = controller.nearbyPipes[Random.Range(0, controller.nearbyPipes.Count - 1)];   //forces to pick another pipe
                    count++;
                }

            }
            else if (selectedPipe != lastPlayedPipe)    //use this pipe
            {
                lastPlayedPipe = selectedPipe;  //update this as the last played pipe too
                int count = 0;
                while ((selectedPipe.GetComponent<AudioSource>().clip == lastPlayedClip) & (count < 10))     //regenerate whilst it's the same clip
                {
                    selectedPipe.GetComponent<AudioSource>().clip = pipeAudioClips[Random.Range(0, pipeAudioClips.Count - 1)];  //choose random pipe sound
                    count++;
                }
                lastPlayedClip = selectedPipe.GetComponent<AudioSource>().clip;
                selectedPipe.GetComponent<AudioSource>().Play();
                selectedPipe.GetComponentInChildren<ParticleSystem>().Emit(1);  //emit smoke once
            }
        }


        playWaitTime = Random.Range(3f, 15f);   //wait a random time period before next sound can be played
        lastPlayedTime = Time.time;
    }

    void Update()
    {
        if ((Time.time > 15f) & (Time.time >= lastPlayedTime + playWaitTime))
        {
            PlayPipeSound();            
        }
    }
}
