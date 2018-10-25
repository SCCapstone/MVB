using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerTest : MonoBehaviour {
    public int speed = 0;

	// Use this for initialization
	void Start () {
		
	} // void Start
	
	// Update is called once per frame
	void Update () {

        // Get the input from the Oculus Go controller (or keyboard)
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Update the player's position based on the input
        Vector3 position = transform.position;
        position.x += moveHorizontal * speed * Time.deltaTime;
        position.z += moveVertical * speed * Time.deltaTime;
        transform.position = position;

    } // void Update
}
