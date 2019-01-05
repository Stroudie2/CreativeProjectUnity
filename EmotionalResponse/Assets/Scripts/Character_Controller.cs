using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Controller : MonoBehaviour {

    private GameObject torch;
    [Header("Movement")]
    public float walkSpeed;
    public float runSpeed;
    private float speed;
    private float tempo;    //used for footstep sound

    private Rigidbody rb;
    private Vector3 move;

    private AudioSource audioSource;
    private Camera mainCam;
    private Vector3 desiredMoveDirection;

    private float joystick_deadzone = 0.3f;
    private bool running = false;

    [Header("Audio")]
    private GameObject audioManager;
    public AudioClip[] clips;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>() as Camera;
        audioManager = GameObject.Find("Audio Source");
        audioSource = audioManager.GetComponent<AudioScript>().audioSource;
        torch = GameObject.FindGameObjectWithTag("Torch").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        Movement(h, v);
	}

    void Movement(float h, float v)
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (torch.activeSelf == true)
            {
                torch.SetActive(false);
                audioSource.pitch = 1.0f;
                audioSource.time = 0.0f;
                audioSource.PlayOneShot(clips[4]);  //using PlayOneShot allows for multiple sounds to be played
                
                //add sound for torch off
            }
            else
            {
                torch.SetActive(true);
                audioSource.pitch = 1.0f;
                audioSource.time = 0.0f;
                audioSource.PlayOneShot(clips[3]);
                //add sound for torch on
            }
        }
        if(Input.GetButton("Run"))
        {
            speed = runSpeed;
            running = true;
            tempo = 1.5f;
        }
        else
        {
            speed = walkSpeed;
            running = false;
            tempo = 1.2f;
        }

        if (v > joystick_deadzone || v < -joystick_deadzone || h > joystick_deadzone || h < -joystick_deadzone)
        {
            Transform cameraTransform = mainCam.transform;
            Vector3 forward = new Vector3(cameraTransform.forward.x, 0f, cameraTransform.forward.z);
            Vector3 right = new Vector3(forward.z, 0f, -forward.x);

            desiredMoveDirection = (forward * v + right * h).normalized;

            Vector3 move = desiredMoveDirection * speed;

            rb.velocity = move;

            //transform.position += move * Time.deltaTime;
            footSteps(tempo, 0.1f);
        }
    }

    void footSteps(float speed, float volume)
    {
        if(!audioSource.isPlaying)
        {
            audioSource.pitch = speed;
            audioSource.volume = volume;
            audioManager.GetComponent<AudioScript>().setAudio(clips[Random.Range(0, 3)]);
            Debug.Log(audioSource.clip);
            audioSource.time = 0.0f;
            audioSource.Play();
        }
    }
}
