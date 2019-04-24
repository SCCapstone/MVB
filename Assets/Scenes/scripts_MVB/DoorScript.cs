using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//MVB Script
public class DoorScript : MonoBehaviour {
    public AudioSource DoorSound;
    private bool opened;
    public Vector3 openedPosition, closedPosition;  
	// Use this for initialization
	void Start () {
        opened = false; //door is closed at the beginning
        closedPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

        if(!opened)
        {
            transform.position = Vector3.Lerp(transform.position, closedPosition, Time.deltaTime * 5f);
        }
        if(opened)
        {
            DoorSound.Play();
            transform.position = Vector3.Lerp(transform.position, openedPosition, Time.deltaTime * 5f);
        }
		
	}
    void OnVRTriggerDown()
    {
        opened = true;
    }

}
