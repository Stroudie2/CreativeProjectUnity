using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public List<AudioClip> audioClips;
    public Character_Controller controller;
    private float lastPlayedTime = 0f;
    float playWaitTime = 0f;

    public GameObject lastPlayedTree;
    public AudioClip lastPlayedClip;

    public void PlayTreeSound()
    {
        if (controller.nearbyTrees.Count > 0)
        {
            GameObject selectedTree = controller.nearbyTrees[Random.Range(0, controller.nearbyTrees.Count)];
            if ((selectedTree == lastPlayedTree) & (controller.nearbyTrees.Count > 1))
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
                    selectedTree.GetComponent<AudioSource>().clip = audioClips[Random.Range(0, audioClips.Count)];
                }
                lastPlayedClip = selectedTree.GetComponent<AudioSource>().clip;
                selectedTree.GetComponent<AudioSource>().Play();
            }
        }


        playWaitTime = Random.Range(3f, 15f);
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
