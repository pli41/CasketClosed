using UnityEngine;
using System;
using System.Collections;

public class FootstepGenerator : MonoBehaviour {
    AudioSource source;
    public AudioClip[] clips;
    bool hasPlayed;
	// Use this for initialization
	void Start () {
        source = GetComponent<AudioSource>();
        hasPlayed = false;
        if(clips.Length > 0)
        {
            source.clip = clips[0];
        }
	}
	
	void OnTriggerEnter(Collider coll)
    {	
		int tag;
		if (int.TryParse(coll.tag, out tag) && tag >= 0 && tag < clips.Length) {
            source.clip = clips[tag];
			Play ();
        }
    }

    void Play()
    {
        source.Play();
    }
    
}
