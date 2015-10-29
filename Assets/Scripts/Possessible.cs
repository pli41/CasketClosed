using UnityEngine;
using System.Collections;

public class Possessible : MonoBehaviour {
	GameObject player;
	bool possessable;
	bool isPossessed = false;
	int possDelay;
	Animator anim;
	public Component[] boneRig;
	public int ReviveTime;
	int time;
	// Use this for initialization
	void Start () {
		possDelay = 0;
		possessable = false;
		anim = GetComponent<Animator> ();
		boneRig = gameObject.GetComponentsInChildren <Rigidbody>();
   
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
				transform.Rotate (0, Input.GetAxisRaw ("Horizontal") * 80.0f * Time.deltaTime, 0, Space.World);
			}
			possDelay += 1;
		} else {
			anim.SetInteger ("AnimState", 0);
		}
	
	}

	void OnTriggerEnter(Collider target){
		if (target.gameObject.tag.Equals ("Player")) {
			Debug.Log ("player Enters");
			player = target.gameObject;
			possessable = true;
		}
	}

	void OnTriggerExit(){
		//possessable = false;
	}

	public void possess(){

		if (possessable && !player.GetComponent<GhostScript>().poss) {

			player.gameObject.GetComponent<CapsuleCollider>().enabled = false;
			player.gameObject.GetComponent<Rigidbody>().useGravity = false;
			transform.position = player.transform.position; 
			//player.transform.SetParent (this.transform);
			player.GetComponentInChildren<SkinnedMeshRenderer> ().enabled = false;
			isPossessed = true;
			player.GetComponent<GhostScript>().poss = true;
            gameObject.GetComponent<CapsuleCollider>().enabled = true;
		}
	}

	public void dePossess(){
		if (possDelay > 10) {
            gameObject.GetComponent<CapsuleCollider>().enabled = true;
            Kill ();
			player.GetComponentInChildren<SkinnedMeshRenderer> ().enabled = true;

			isPossessed = false;

            
            player.GetComponent<GhostScript>().poss = false;
			possDelay = 0;

			player.gameObject.GetComponent<CapsuleCollider> ().enabled = true;
			player.gameObject.GetComponent<Rigidbody> ().useGravity = true;
			possessable = false;
		}
	}

	public void Kill(){
		foreach (Rigidbody ragbone in boneRig) {
			ragbone.isKinematic = false;
		}
		GetComponent<Animator> ().enabled = false;
		time = 0;
	}

	void Revive(){
		foreach (Rigidbody ragbone in boneRig) {
			ragbone.isKinematic = true;
		}
		GetComponent<Animator> ().enabled = true;
		possessable = true;
	}

}
