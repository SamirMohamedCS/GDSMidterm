using UnityEngine;
using System.Collections;

public class SoundTrigger : MonoBehaviour {

    public AudioSource mySound;
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
            mySound.Play();
        //mySound.isPlaying
	}
}
