using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxHitFloor : MonoBehaviour {

    public AudioClip floorHitSound;
    public bool FirstHitFloor = false;

    private void OnTriggerEnter(Collider other)
    {
        if ((other.tag == "Floor") & (FirstHitFloor))
        {
            GetComponent<AudioSource>().PlayOneShot(floorHitSound);
            FirstHitFloor = false;  //stops sound playing multiple times
        }
    }

}
