using UnityEngine;
using System.Collections;

public class Trampoline : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag == "NPC"){
			col.attachedRigidbody .AddForce(Vector3.up * 1000f, ForceMode.Impulse);
		}
	}
}
