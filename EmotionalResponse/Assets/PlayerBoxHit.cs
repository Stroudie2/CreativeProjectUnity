using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoxHit : MonoBehaviour {

    Character_Controller player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Character_Controller>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerHead")
        {
            player.boxFly = true;
            transform.gameObject.SetActive(false);
        }
    }
}
