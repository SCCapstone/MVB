using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeMusic : MonoBehaviour {
    public Slider volume;
    public AudioSource myMusic;
	
	
	// Update is called once per frame
	void Update () {
        myMusic.volume = volume.value;
	}
}
