using UnityEngine;
using System.Collections;

public class AudioScript : MonoBehaviour {


	AudioSource audio;
	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource>();
	}

	void OnCollisionEnter (Collision other) 
	{
		if(other.gameObject.tag == "Player")
		{
			audio.Play();
		}
		
	}
	void OnTriggerEnter (Collider other) 
	{
		if(other.gameObject.tag == "Player")
		{	
			audio.Play();
		}
		
	}
	// Update is called once per frame
	void Update () {

	}
}
