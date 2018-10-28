using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public int speed = 10;//speed is faster
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // get input data from keyboard or controller
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // update player position based on input
        Vector3 position = transform.position;
        position.x += moveHorizontal * speed * Time.deltaTime;
        position.z += moveVertical * speed * Time.deltaTime;
        transform.position = position;

        if(Input.GetKey("space"))
        {
            transform.Translate(0, 0.2f, 0);
        }
   


    }
  

}
