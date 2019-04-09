using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoxHit : MonoBehaviour {

    Character_Controller player;
    FlyToLocation flyingBoxpile;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Character_Controller>();
        if (gameObject.name == "BoxFlyToLocationTrigger")
        {
            flyingBoxpile = GameObject.Find("Flying Boxpile").GetComponent<FlyToLocation>();
        }
        else if (gameObject.name == "BoxFlyToLocationTrigger2")
        {
            flyingBoxpile = GameObject.Find("Flying Boxpile2").GetComponent<FlyToLocation>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerHead")
        {
            player.boxFly = true;
            transform.gameObject.SetActive(false);
            Destroy(gameObject);

            if (gameObject.name == "BoxFlyToLocationTrigger")
            {
                flyingBoxpile.boxFly = true;
            }
            else if (gameObject.name == "BoxFlyToLocationTrigger2")
            {
                flyingBoxpile.boxFly2 = true;
            }
        }
    }
}
