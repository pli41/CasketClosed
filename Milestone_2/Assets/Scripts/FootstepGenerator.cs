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
        if(coll.tag.Equals("1") || coll.tag.Equals("2") || coll.tag.Equals("3") 
            || coll.tag.Equals("0"))
        {

            source.clip = clips[Int32.Parse(coll.tag)];
        }
    }

    void Play()
    {
        source.Play();
    }
    
}
