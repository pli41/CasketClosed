using UnityEngine;
using System.Collections;

public class RagdollScript : MonoBehaviour {
	public Component[] boneRig;

	// Use this for initialization
	void Start () {
		boneRig = gameObject.GetComponentsInChildren <Rigidbody>();

	}
	
	// Update is called once per frame
	public void Kill(){
		foreach (Rigidbody ragbone in boneRig) {
			ragbone.isKinematic = false;
		}
		GetComponent<Animator> ().enabled = false;
	}
}
