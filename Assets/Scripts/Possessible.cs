using UnityEngine;
using System.Collections;

public class Possessible : MonoBehaviour {
	GameObject player;
	bool possessable;
	bool isPossessed = false;
	int possDelay;
	// Use this for initialization
	void Start () {
		possDelay = 0;
		possessable = false;
	}

	void Update () { 
		if (isPossessed) {
			transform.position = player.transform.position;
			possDelay+=1;
		}
	}

	void OnTriggerEnter(Collider target){
		if (target.gameObject.tag.Equals ("Player")) {
			player = target.gameObject;
			possessable = true;
		}
	}

	void OnTriggerExit(){
		possessable = false;
	}

	public void possess(){
		if (possessable) {

				isPossessed = true;
			gameObject.GetComponent<CapsuleCollider>().enabled = false;
			gameObject.GetComponent<Rigidbody>().useGravity = false;
			transform.position = player.transform.position; 
			this.transform.SetParent (player.transform);
			player.GetComponent<MeshRenderer> ().enabled = false;
		}
	}

	public void dePossess(){
		if (possDelay > 10) {
			player.GetComponent<MeshRenderer> ().enabled = true;
			isPossessed = false;
			this.transform.SetParent (null);
			transform.Translate (new Vector3 (1, 0, 1));
			gameObject.GetComponent<CapsuleCollider> ().enabled = true;
			gameObject.GetComponent<Rigidbody> ().useGravity = true;
			possDelay = 0;
		}
	}


}
