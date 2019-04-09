using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateCollapse : MonoBehaviour {

    public GameObject OldBoxPile;
    public GameObject newBoxPile;
    public AudioSource audiosource;

	// Use this for initialization
	void Start () {
        newBoxPile.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PlayerHead")
        {
            audiosource.time = 0.0f;
            audiosource.Play();
            OldBoxPile.SetActive(false);
            newBoxPile.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}
