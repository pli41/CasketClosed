using UnityEngine;
using System.Collections;

public class BasicDoorScript : MonoBehaviour {
	Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider target) {
		Debug.Log ("Trying to open door");
		if (target.tag.Equals("NPC")){
    		anim.SetInteger("state", 1);
		}
	}

}
