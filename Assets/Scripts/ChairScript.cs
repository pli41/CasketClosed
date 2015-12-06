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
<<<<<<< HEAD
	void OnCollisionEnter(Collision collision){
=======
	void OnCollisionEnter(){
		Collision collision = GetComponent<Collision> ();
>>>>>>> a976ca3e268049dbf5155204b55f741b36802ae0
		if(collision.collider.tag == "NPC")
		{
			knockingdown.Play();
		}

	
	}
}
