using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoxHit : MonoBehaviour {

    Character_Controller player;
    FlyToLocation flyingBoxpile;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Character_Controller>();
        flyingBoxpile = GameObject.Find("Flying Boxpile").GetComponent<FlyToLocation>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerHead")
        {
            player.boxFly = true;
            transform.gameObject.SetActive(false);

            if (gameObject.name == "BoxFlyToLocationTrigger")
            {
                flyingBoxpile.boxFly = true;
            }
        }
    }
}
