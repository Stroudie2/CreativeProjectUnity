using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public List<AudioClip> treeAudioClips;
    public Character_Controller controller;
    private float lastPlayedTime = 0f;
    float playWaitTime = 0f;

    public GameObject lastPlayedTree;
    public AudioClip lastPlayedClip;

    public void PlayTreeSound()
    {
        if (controller.nearbyTrees.Count > 0)   //checks trees around player
        {
            GameObject selectedTree = controller.nearbyTrees[Random.Range(0, controller.nearbyTrees.Count)];    //pick random tree from around player
            if ((selectedTree == lastPlayedTree) & (controller.nearbyTrees.Count > 1))  //don't play sound at same location twice
            {
                while (selectedTree == lastPlayedTree)
                {
                    selectedTree = controller.nearbyTrees[Random.Range(0, controller.nearbyTrees.Count)];   //forces to pick another tree
                }

            }
            else if (selectedTree != lastPlayedTree)
            {
                lastPlayedTree = selectedTree;
                while (selectedTree.GetComponent<AudioSource>().clip == lastPlayedClip)     //regenerate whilst it's the same
                {
                    selectedTree.GetComponent<AudioSource>().clip = treeAudioClips[Random.Range(0, treeAudioClips.Count)];  //choose random tree sound
                }
                lastPlayedClip = selectedTree.GetComponent<AudioSource>().clip;
                selectedTree.GetComponent<AudioSource>().Play();
            }
        }


        playWaitTime = Random.Range(3f, 15f);   //wait a random time period before next sound can be played
        lastPlayedTime = Time.time;
    }

    void Update()
    {
        if (Time.time >= lastPlayedTime + playWaitTime)
        {
            PlayTreeSound();            
        }
    }
}
