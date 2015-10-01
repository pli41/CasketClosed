using UnityEngine;
using System.Collections;

public class Possessible : MonoBehaviour {
	GameObject player;
	bool possessable;
	bool isPossessed = false;
	int possDelay;
	Animator anim;
	// Use this for initialization
	void Start () {
		possDelay = 0;
		possessable = false;
		anim = GetComponent<Animator> ();
	}

	void Update () { 
		if (isPossessed) {
			player.transform.position = transform.position;
			player.transform.rotation = transform.rotation;
			if (Input.GetAxisRaw ("Vertical") > 0) {
				anim.SetInteger ("AnimState", 1);
			} else if (Input.GetAxisRaw ("Vertical") < 0) {
				anim.SetInteger ("AnimState", -1);
			} else {
				anim.SetInteger ("AnimState", 0);
			}
			if (Input.GetAxisRaw ("Horizontal") != 0) {
				transform.Rotate (0, Input.GetAxisRaw ("Horizontal")*80.0f * Time.deltaTime, 0, Space.World);
			}
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
		if (possessable && !player.GetComponent<GhostScript>().poss) {
			player.GetComponent<GhostScript>().poss = true;
			player.gameObject.GetComponent<CapsuleCollider>().enabled = false;
			player.gameObject.GetComponent<Rigidbody>().useGravity = false;
			transform.position = player.transform.position; 
			player.transform.SetParent (this.transform);
			player.GetComponentInChildren<SkinnedMeshRenderer> ().enabled = false;
			isPossessed = true;

			Debug.Log("Possessed");
		}
	}

	public void dePossess(){
		if (possDelay > 10) {
			player.GetComponentInChildren<SkinnedMeshRenderer> ().enabled = true;
			isPossessed = false;
			player.transform.SetParent (null);
			transform.Translate (new Vector3 (1, 0, 1));
			player.gameObject.GetComponent<CapsuleCollider> ().enabled = true;
			player.gameObject.GetComponent<Rigidbody> ().useGravity = true;
			player.GetComponent<GhostScript>().poss = false;
			possDelay = 0;
		}
	}


}
