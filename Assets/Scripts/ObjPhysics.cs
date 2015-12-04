using UnityEngine;
using System.Collections;

public class ObjPhysics : MonoBehaviour {


	
//	Sound effects for Dungeon level
	public AudioClip soundEffect;
	private AudioSource source; 
	private float volLowRange = 0.5f;
	private float volHighRange = 1.0f;

//	End Dungeon Sounds
	
	void Awake(){
		source = GetComponent<AudioSource> ();

	}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider target){
		if (target.tag.Equals ("Player")) {
			Debug.Log ("Player walking here");
			source.PlayOneShot(soundEffect, 1F);

		}
	}

	void OnTriggerExit(Collider target){
		if (target.tag.Equals ("Player") && gameObject.tag.Equals("Stairs")) {
			if(source.isPlaying){
				source.Stop();
			}
		} 
	}

}
