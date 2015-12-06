using UnityEngine;
using System.Collections;

public class ChairScript : MonoBehaviour {
	AudioSource knockingdown;
	//Transform transform;
	// Use this for initialization
	void Start () {
		knockingdown = GetComponent<AudioSource> ();
		//transform = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {

	
	}
	void OnCollisionEnter(){
		Collision collision = GetComponent<Collision> ();
		if(collision.collider.tag == "NPC")
		{
			knockingdown.Play();
		}

	
	}
}
