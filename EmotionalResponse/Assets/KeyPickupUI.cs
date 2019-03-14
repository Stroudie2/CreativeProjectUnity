using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickupUI : MonoBehaviour {
    Rect rect;
    public Texture texture;
    public float displayTime = 0.0f;
	// Use this for initialization
	void Start () {
        float size = Screen.width * 0.1f;
        rect = new Rect(Screen.width / 2 - size / 2, Screen.height * 0.7f, size, size);
        
	}
	
	// Update is called once per frame
	void Update () {
		if (displayTime > 0f)
        {
            displayTime -= Time.deltaTime;
        }
	}

    private void OnGUI()
    {
        if (displayTime > 0)
        {
            GUI.DrawTexture(rect, texture);
        }
    }
}
